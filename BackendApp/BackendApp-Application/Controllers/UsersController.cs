using BackendApp_Domain.DTO.Request;
using BackendApp_Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUsersService _userServices;

        public UsersController(IUsersService userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            var authResponse = await _userServices.Login(loginRequest);

            return Ok(authResponse);
        }
    }
}
