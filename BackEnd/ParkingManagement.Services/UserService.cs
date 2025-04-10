using AutoMapper;
using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Interfaces;
using ParkingManagement.Services.Exceptions;


namespace ParkingManagement.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IMapper _mapper { get; set; }
        public IJwtService _jwtService { get; set; }
        public IHashPasswordService _hashPassword { get; set; }

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IJwtService jwtService, IHashPasswordService hashPassword)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
            _hashPassword = hashPassword;
        }

        public async Task<LoginResponseDTO> GetUserByUsernameAndPasswordAsync(LoginDTO login)
        {
            User user = await _unitOfWork.UserRepository.GetByEmailAndPasswordAsync(login.Email, _hashPassword.HashPassword(login.Password));
            if (user is not null)
            {
                string role = "";

                if(user is Admin)
                {
                    _jwtService.AddRoles("Admin");
                    role = "Admin";
                }
                else if (user is Artisan)
                {
                    _jwtService.AddRoles("Artisan");
                    role = "Artisan";
                }
                else if (user is Client)
                {
                    _jwtService.AddRoles("Client");
                    role = "Client";
                }

                LoginResponseDTO response = new LoginResponseDTO
                {
                    Id = user.Id,
                    Token = _jwtService.GenerateToken(user.Id.ToString()),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Photo = user.Photo,
                    Role = role
                };

                return response;
            }
            return null;
        }

        public async Task<SignUpClientDTO> RegisterClientAsync(SignUpClientDTO newClient)
        {
            var existingUser = await _unitOfWork.UserRepository.GetClientByEmailAsync(newClient.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistException("Un utilisateur avec cet email existe déjà.");
            }

            Client client = _mapper.Map<Client>(newClient);
            client.Password = _hashPassword.HashPassword(newClient.Password);
            await _unitOfWork.UserRepository.AddClientAsync(client);
            await _unitOfWork.SaveChangesAsync();
            return newClient;
        }


        public async Task<GetUserByIdDTO?> GetUserInfosAsync(int Id)
        {
            var existingUser = await _unitOfWork.UserRepository.GetClientByIdAsync(Id);
            if(existingUser != null)
            {
                return _mapper.Map<GetUserByIdDTO>(existingUser);
            }
            return null;
        }

    }
}
