using Microsoft.AspNetCore.Mvc;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersApp _application;
        public UserController(IUsersApp application) 
        {
            _application = application;
        }

        [HttpPost]
        [ProducesResponseType<Login.Response>(StatusCodes.Status200OK)]
        [Route("auth/token")]
        public async Task<IActionResult> Login([FromBody] Login.Request login)
        {
            var token = await _application.Login(login);
            return Ok(token);
        }
    }
}
