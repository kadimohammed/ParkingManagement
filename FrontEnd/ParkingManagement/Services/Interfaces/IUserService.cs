using ParkingManagement.Models.Responses;

namespace ParkingManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<GetUserByIdResponse?> GetById(string ApiName);
    }
}
