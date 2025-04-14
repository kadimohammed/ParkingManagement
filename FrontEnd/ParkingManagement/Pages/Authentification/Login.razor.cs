using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using ParkingManagement.Models.Requests;
using ParkingManagement.Models.Responses;
using ParkingManagement.Resources;
using ParkingManagement.Utils;
using System.Net.Http.Json;


namespace ParkingManagement.Pages.Authentification
{
    public partial class Login
    {
        private LoginModel loginModel = new();
        private string? errorMessage;
        private bool isSubmitting = false;

        [Inject]
        public HttpClient _httpClient { get; set; }

        [Inject]
        public IStringLocalizer<Resource> Loc { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task HandleLogin()
        {
            isSubmitting = true;
            errorMessage = null; // Réinitialiser l'erreur

            try
            {
                var response = await _httpClient.PostAsJsonAsync("Authentication", loginModel);
                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    if (loginResponse != null)
                    {
                        ((ApiAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(loginResponse);
                        NavigationManager.NavigateTo("/Parking/map");
                    }
                    else
                    {
                        errorMessage = "Erreur d'authentification";
                    }
                }
                else
                {
                    errorMessage = "Email ou mot de passe incorrect";
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Erreur de connexion au serveur : {ex.Message}";
            }
            finally
            {
                isSubmitting = false;
            }
        }

    }
}
