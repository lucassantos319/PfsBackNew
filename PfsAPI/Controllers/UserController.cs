using Microsoft.AspNetCore.Mvc;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersApp _application;
        public UserController(IUsersApp application) 
        {
            _application = application;
        }

        [HttpPost]
        [ProducesResponseType<LoginViewModel.Response>(StatusCodes.Status200OK)]
        [Route("auth/token")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel.Request login)
        {
            var token = await _application.Login(login);
            return Ok(token);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<User>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            var user = await _application.GetUserById(id);
            return Ok(user);
        }
    }
}
