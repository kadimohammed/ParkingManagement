using ParkingManagement.Models.Requests;
using ParkingManagement.Models.Responses;

namespace ParkingManagement.Services.Interfaces
{
    public interface IParkingService
    {
        Task Delete(string ApiName);
        Task<IList<GetParkingsResponse>> GetAll(string ApiName);
        Task<GetParkingByIdResponse> GetById(string ApiName);
        Task<bool> Add(AddParkingRequest parkingModel, string apiUrl);
        Task<bool> Update(UpdateParkingRequest parkingModel, string apiUrl);
    }
}
