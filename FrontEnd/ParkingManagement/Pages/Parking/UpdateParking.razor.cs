using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using ParkingManagement.Models.Requests;
using ParkingManagement.Models.Responses;
using ParkingManagement.Services.Interfaces;

namespace ParkingManagement.Pages.Parking
{
    public partial class UpdateParking
    {
        private UpdateParkingRequest parkingModel = new();

        [Inject]
        public IParkingService ParkingService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public GetParkingByIdResponse Parking { get; set; }

        [Parameter]
        public int Id { get; set; }

        private string endWorkTime;
        private string startWorkTime;

        protected override async Task OnInitializedAsync()
        {
            Parking = await ParkingService.GetById($"Parking/{Id}");
            parkingModel.Id = Id;
            parkingModel.Surface = Parking.Surface;
            parkingModel.NomParcking = Parking.NomParcking;
            parkingModel.Latitude = Parking.Latitude;
            parkingModel.Longitude = Parking.Longitude;
            parkingModel.CreationDate = Parking.CreationDate;
            parkingModel.Adresse = Parking.Adresse;
            parkingModel.IsWorking = Parking.IsWorking;
            parkingModel.TimeStartWork = Parking.TimeStartWork;
            parkingModel.TimeEndWork = Parking.TimeEndWork;
            
            if (parkingModel.Days == null || parkingModel.Days.Length != 7)
            {
                parkingModel.Days = new bool[7];
            }

            if (Parking.ParkingDays != null)
            {
                foreach (var parkingDay in Parking.ParkingDays)
                {
                    parkingModel.Days[(int)parkingDay.Day] = true; 
                }
            }

            startWorkTime = parkingModel.TimeStartWork.ToString("HH\\:mm");
            endWorkTime = parkingModel.TimeEndWork.ToString("HH\\:mm");
        }


        public void GoBack()
        {
            navigationManager.NavigateTo("/Parkings");
        }


        private async Task HandleValidSubmit()
        {
            var result = await ParkingService.Update(parkingModel, "Parking");
            navigationManager.NavigateTo("Parkings");

        }



        private void HandleImageChange(InputFileChangeEventArgs e)
        {
            if (TimeOnly.TryParse(startWorkTime, out var start))
                parkingModel.TimeStartWork = start;

            if (TimeOnly.TryParse(endWorkTime, out var end))
                parkingModel.TimeEndWork = end;
            parkingModel.Picture = e.File;
        }
    }
}
