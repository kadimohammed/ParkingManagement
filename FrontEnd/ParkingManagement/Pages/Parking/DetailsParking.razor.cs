using Microsoft.AspNetCore.Components;
using ParkingManagement.Models.Responses;
using ParkingManagement.Services.Interfaces;

namespace ParkingManagement.Pages.Parking
{
    public partial class DetailsParking
    {
        [Inject]
        public IParkingService ParkingService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public GetParkingByIdResponse Parking { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Parking = await ParkingService.GetById($"Parking/{Id}");
        }

        public void GoBack()
        {
            NavigationManager.NavigateTo("/Parkings");
        }

        public void NavigateToMap()
        {
            if (Parking != null)
            {
                NavigationManager.NavigateTo($"/Parking/Map?lat={Parking.Latitude}&lng={Parking.Longitude}&name={Parking.NomParcking}");
            }
        }
    }
}
