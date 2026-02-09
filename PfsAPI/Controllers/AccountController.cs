using Microsoft.AspNetCore.Mvc;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers
{
    [ApiController]
    [Route("v1/account")]
    public class AccountController : ControllerBase
    {
        readonly IAccountApp _accountApp;
        public AccountController(IAccountApp accountApp)
        {
            _accountApp = accountApp;
        }

        [HttpPost]
        [ProducesResponseType<Result<Account>>(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AccountViewModel account)
        {
            var result = await _accountApp.Create(account);
            if (result.PossuiErro)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
