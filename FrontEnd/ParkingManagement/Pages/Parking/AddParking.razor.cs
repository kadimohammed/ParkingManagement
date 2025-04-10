using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using ParkingManagement.Models.Requests;
using ParkingManagement.Services.Interfaces;

namespace ParkingManagement.Pages.Parking
{
    public partial class AddParking
    {
        private AddParkingRequest parkingModel = new();

        [Inject]
        public IParkingService ParkingService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IJSRuntime JSruntime { get; set; }

        private string startWorkTime;
        private string endWorkTime;


        protected override void OnInitialized()
        {
            if (parkingModel.Days == null || parkingModel.Days.Length != 7)
            {
                parkingModel.Days = new bool[7];
            }
            startWorkTime = parkingModel.TimeStartWork.ToString("HH\\:mm");
            endWorkTime = parkingModel.TimeEndWork.ToString("HH\\:mm");
        }


        private async Task HandleValidSubmit()
        {
            var result = await ParkingService.Add(parkingModel, "Parking");
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
