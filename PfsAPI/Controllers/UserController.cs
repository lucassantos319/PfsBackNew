using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PfsDomain.Requests;

namespace PfsAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("auth/token")]
        public IActionResult Login([FromBody] Login.Request login)
        {
            return Ok();
        }
    }
}
