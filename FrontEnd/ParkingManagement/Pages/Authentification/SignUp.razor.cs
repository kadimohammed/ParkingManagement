using Microsoft.AspNetCore.Components;
using ParkingManagement.Models.Requests;
using ParkingManagement.Models.Responses;
using System.Net.Http.Json;

namespace ParkingManagement.Pages.Authentification
{
    public partial class SignUp
    {
        private SignUpClientRequest signModel = new();
        private string? errorMessage;
        private bool isSubmitting = false;
        private string confirmPassword = "";

        [Inject]
        public HttpClient _httpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task HandleSignUp()
        {
            isSubmitting = true;
            errorMessage = null;
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Authentication/SignUpClient", signModel);

                if (response.IsSuccessStatusCode)
                {
                    NavigationManager.NavigateTo("/login");
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (content.Contains("Un utilisateur avec cet email existe déjà.", StringComparison.OrdinalIgnoreCase) ||
                        response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        errorMessage = "Cette adresse email est déjà utilisée. Veuillez utiliser une autre adresse ou vous connecter.";
                    }
                    else
                    {
                        errorMessage = "Données incorrectes. Veuillez vérifier vos informations.";
                    }
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
