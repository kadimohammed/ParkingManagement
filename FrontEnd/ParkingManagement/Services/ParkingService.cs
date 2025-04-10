using ParkingManagement.Models.Requests;
using ParkingManagement.Models.Responses;
using ParkingManagement.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ParkingManagement.Services
{
    public class ParkingService : IParkingService
    {
        private readonly HttpClient _httpClient;

        public ParkingService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task Delete(string ApiName)
        {
            await this._httpClient.DeleteAsync(ApiName);
        }

        public async Task<IList<GetParkingsResponse>> GetAll(string ApiName)
        {
            try
            {
                var response = await this._httpClient.GetFromJsonAsync<IList<GetParkingsResponse>>(ApiName);
                return response ?? new List<GetParkingsResponse>();
            }
            catch (Exception)
            {
                return new List<GetParkingsResponse>();
            }
        }

        public async Task<GetParkingByIdResponse?> GetById(string ApiName)
        {
            return await this._httpClient.GetFromJsonAsync<GetParkingByIdResponse>(ApiName);
        }


        public async Task<bool> Add(AddParkingRequest parkingModel, string apiUrl)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(parkingModel.Latitude.ToString()), "Latitude");
            content.Add(new StringContent(parkingModel.Longitude.ToString()), "Longitude");
            content.Add(new StringContent(parkingModel.NomParcking ?? ""), "NomParcking");
            content.Add(new StringContent(parkingModel.Adresse ?? ""), "Adresse");
            content.Add(new StringContent(parkingModel.Surface.ToString()), "Surface");
            content.Add(new StringContent(parkingModel.TimeStartWork.ToString()), "TimeStartWork");
            content.Add(new StringContent(parkingModel.TimeEndWork.ToString()), "TimeEndWork");
            content.Add(new StringContent(parkingModel.CreationDate.ToString("yyyy-MM-dd")), "CreationDate");
            content.Add(new StringContent(parkingModel.IsWorking.ToString()), "IsWorking");

            for (int i = 0; i < parkingModel.Days.Length; i++)
            {
                content.Add(new StringContent(parkingModel.Days[i].ToString()), "Days");
            }

            if (parkingModel.Picture != null)
            {
                var stream = parkingModel.Picture.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); // 10 Mo
                var streamContent = new StreamContent(stream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(parkingModel.Picture.ContentType);
                content.Add(streamContent, "Picture", parkingModel.Picture.Name);
            }

            var response = await _httpClient.PostAsync(apiUrl, content);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> Update(UpdateParkingRequest parkingModel, string apiUrl)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(parkingModel.Id.ToString()), "Id");
            content.Add(new StringContent(parkingModel.Latitude.ToString()), "Latitude");
            content.Add(new StringContent(parkingModel.Longitude.ToString()), "Longitude");
            content.Add(new StringContent(parkingModel.NomParcking ?? ""), "NomParcking");
            content.Add(new StringContent(parkingModel.Adresse ?? ""), "Adresse");
            content.Add(new StringContent(parkingModel.Surface.ToString()), "Surface");
            content.Add(new StringContent(parkingModel.TimeStartWork.ToString()), "TimeStartWork");
            content.Add(new StringContent(parkingModel.TimeEndWork.ToString()), "TimeEndWork");
            content.Add(new StringContent(parkingModel.CreationDate.ToString("yyyy-MM-dd")), "CreationDate");
            content.Add(new StringContent(parkingModel.IsWorking.ToString()), "IsWorking");

            for (int i = 0; i < parkingModel.Days.Length; i++)
            {
                content.Add(new StringContent(parkingModel.Days[i].ToString()), "Days");
            }

            if (parkingModel.Picture != null)
            {
                var stream = parkingModel.Picture.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(parkingModel.Picture.ContentType);
                content.Add(streamContent, "Picture", parkingModel.Picture.Name);
            }

            HttpResponseMessage response = await _httpClient.PutAsync(apiUrl, content);
            return response.IsSuccessStatusCode;
        }


    }
}
