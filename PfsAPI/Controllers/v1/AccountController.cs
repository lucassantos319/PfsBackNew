using Microsoft.AspNetCore.Mvc;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsShared;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v1/account")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _accountApp.GetById(id);
            if (result.PossuiErro)
                return BadRequest(result);
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var result = await _accountApp.DeleteById(id);
            if ( result.PossuiErro )
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("painel/{id}")]
        public async Task<IActionResult> GetByPainelId(Guid painelId)
        {
            var account = await _accountApp.GetByPainelId(painelId);
            if (account.PossuiErro)
                return BadRequest(account);

            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AccountViewModel accountViewModel)
        {
            var account = await _accountApp.Update(accountViewModel);
            if (account.PossuiErro)
                return BadRequest(account);

            return Ok(account);
        }
    }
}
