using Microsoft.AspNetCore.Mvc;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace PfsAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        readonly IUsersApp _application;
        public AuthController(IUsersApp application)
        {
            _application = application;
        }

        [HttpPost]
        [ProducesResponseType<LoginViewModel.LoginResponse>(StatusCodes.Status200OK)]
        [Route("token")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel.LoginRequest login)
        {
            var token = await _application.Login(login);
            return Ok(token);
        }

        //TODO: Refresh Token & Logout
    }
}
