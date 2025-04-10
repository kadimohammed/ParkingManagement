using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ParkingManagement.Models.Responses;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace ParkingManagement.Utils
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrWhiteSpace(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // convert le token pour extraire les informations (claims)
            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }




        public void MarkUserAsAuthenticated(LoginResponse login)
        {
            _localStorage.SetItemAsync("authToken", login.Token);
            _localStorage.SetItemAsync("authUserId", login.Id);
            _localStorage.SetItemAsync("authUserFirstName", login.FirstName);
            _localStorage.SetItemAsync("authUserLastName", login.LastName);
            _localStorage.SetItemAsync("authUserEmail", login.Email);
            _localStorage.SetItemAsync("authUserPhone", login.Phone);
            _localStorage.SetItemAsync("authUserPhoto", login.Photo);
            _localStorage.SetItemAsync("authUserRole", login.Role);
            var claims = ParseClaimsFromJwt(login.Token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            // notif Blazor que letat dauthentification a changé
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }


        public void MarkUserAsLoggedOut()
        {
            _localStorage.RemoveItemAsync("authToken");
            _localStorage.RemoveItemAsync("authUserId");
            _localStorage.RemoveItemAsync("authUserFirstName");
            _localStorage.RemoveItemAsync("authUserLastName");
            _localStorage.RemoveItemAsync("authUserEmail");
            _localStorage.RemoveItemAsync("authUserPhone");
            _localStorage.RemoveItemAsync("authUserPhoto");
            _localStorage.RemoveItemAsync("authUserRole");
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }



        public async Task<int> GetUserId()
        {
            return await _localStorage.GetItemAsync<int>("authUserId");
        }


        public async Task<LoginResponse> GetUserData()
        {
            LoginResponse login = new LoginResponse();
            login.FirstName = await _localStorage.GetItemAsync<string>("authUserFirstName");
            login.LastName=  await _localStorage.GetItemAsync<string>("authUserLastName");
            login.Email= await _localStorage.GetItemAsync<string>("authUserEmail");
            login.Photo= await _localStorage.GetItemAsync<string>("authUserPhone");
            login.Photo = await _localStorage.GetItemAsync<string>("authUserPhoto");
            login.Role =  await _localStorage.GetItemAsync<string>("authUserRole");

            return login;
        }

    }
}