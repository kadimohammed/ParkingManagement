using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Interfaces;
using ParkingManagement.Services.Exceptions;

namespace ParkingManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginModel)
        {
            LoginResponseDTO response = await _userService.GetUserByUsernameAndPasswordAsync(loginModel);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }


        [HttpPost("SignUpClient")]
        public async Task<IActionResult> ClientSignUp([FromBody] SignUpClientDTO loginModel)
        {
            try
            {
                SignUpClientDTO response = await _userService.RegisterClientAsync(loginModel);
                if (response == null)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (UserAlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
