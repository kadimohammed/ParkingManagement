using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ParkingManagement.Models.Responses;
using ParkingManagement.Services.Interfaces;

namespace ParkingManagement.Pages.Parking
{
    public partial class ParkingsLocation
    {
        [Inject]
        public IParkingService ParkingService { get; set; }

        [Parameter]
        public int? Id { get; set; }

        private GetParkingByIdResponse? SingleParking { get; set; }
        private IList<GetParkingsResponse>? ParkingList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id.HasValue)
            {
                SingleParking = await ParkingService.GetById($"Parking/{Id}");
            }
            else
            {
                ParkingList = await ParkingService.GetAll("Parking");
            }



            if (Id.HasValue && SingleParking != null)
            {
                await JSRuntime.InvokeVoidAsync("initializeMap",
                    SingleParking.Latitude,
                    SingleParking.Longitude,
                    SingleParking.NomParcking,
                    false,
                    null,
                    SingleParking.Adresse);
            }
            else if (ParkingList != null && ParkingList.Any())
            {
                var parkingsData = ParkingList.Select(p => new
                {
                    id = p.Id,
                    lat = p.Latitude,
                    lng = p.Longitude,
                    name = p.NomParcking,
                    address = p.Adresse
                }).ToArray();

                double centerLat = parkingsData.Average(p => p.lat);
                double centerLng = parkingsData.Average(p => p.lng);

                // Initialiser la carte avec tous les parkings
                await JSRuntime.InvokeVoidAsync("initializeMap",
                    centerLat,
                    centerLng,
                    "Tous les parkings",
                    true,
                    parkingsData);
            }
        }


        public void GoBack()
        {
            NavigationManager.NavigateTo("/Parkings");
        }


    }
}
