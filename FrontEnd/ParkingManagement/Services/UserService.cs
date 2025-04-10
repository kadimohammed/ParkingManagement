using ParkingManagement.Models.Responses;
using ParkingManagement.Services.Interfaces;
using System.Net.Http.Json;

namespace ParkingManagement.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<GetUserByIdResponse?> GetById(string ApiName)
        {
            return await this._httpClient.GetFromJsonAsync<GetUserByIdResponse>(ApiName);
        }
    }
}
