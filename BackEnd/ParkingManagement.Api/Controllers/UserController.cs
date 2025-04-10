using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Core.Interfaces;

namespace ParkingManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserInfosAsync(id);

            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}
