using ParkingManagement.Core.DTOS;

namespace ParkingManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponseDTO> GetUserByUsernameAndPasswordAsync(LoginDTO login);
        Task<SignUpClientDTO> RegisterClientAsync(SignUpClientDTO newClient);
        Task<GetUserByIdDTO?> GetUserInfosAsync(int Id);
    }
}
