using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ParkingManagement.Models.Responses;
using ParkingManagement.Services.Interfaces;

namespace ParkingManagement.Pages.Parking
{
    public partial class Parkings
    {
        [Inject]
        public IParkingService ParkingService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IJSRuntime JSruntime { get; set; }

        public IList<GetParkingsResponse>? ParkingList { get; set; } = null;


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(2000);
            ParkingList = await ParkingService.GetAll("Parking");
        }

        private void AjouterParking()
        {
            navigationManager.NavigateTo("Parking/add");
        }

        private void ModifierParking(int id)
        {
            navigationManager.NavigateTo($"Parking/update/{id}");
        }
        private void VoirDetails(int id)
        {
            navigationManager.NavigateTo($"/Parking/Details/{id}");
        }

        private void VoirLocation(int id)
        {
            navigationManager.NavigateTo($"/Parking/map/{id}");
        }

        private async Task SupprimerParking(int id)
        {
            var confirmed = await JSruntime.InvokeAsync<bool>("confirm", "Delete Row ?");
            if (confirmed)
            {
                await ParkingService.Delete($"Parking/{id}");
                GetParkingsResponse? res = ParkingList?.FirstOrDefault(c => c.Id == id);
                if (res is not null)
                {
                    ParkingList?.Remove(res);
                }
            }
        }
    }
}
