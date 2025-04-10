using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ParkingManagement.Models.Responses;
using ParkingManagement.Services;
using ParkingManagement.Services.Interfaces;
using ParkingManagement.Utils;

namespace ParkingManagement.Pages.Authentification
{
    public partial class Profile
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public GetUserByIdResponse user { get; set; }


        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int authUserId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetUserId();
            user = await UserService.GetById($"User/{authUserId}");
        }

        //public void GoBack()
        //{
        //    navigationManager.NavigateTo("/");
        //}
    }
}
