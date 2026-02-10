using Microsoft.AspNetCore.Mvc;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers
{
    [Route("api/v1/painel")]
    [ApiController]
    public class PainelController : ControllerBase
    {
        readonly IPainelApp _painelApp; 
        public PainelController(IPainelApp painelApp) 
        {
            _painelApp = painelApp;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PainelViewModel painel)
        {
            var createPainel = await _painelApp.Create(painel);
            return CreatedAtAction(nameof(Create), new { id = createPainel.Valor.Id }, createPainel.Valor);
        }

        [HttpPost]
        [Route("{id}/add/user/")]
        public async Task<IActionResult> AddUserPainel([FromRoute] Guid id, [FromBody] PainelUserViewModel painelUser)
        {
            //var addUserPainel = await _painelApp.Create();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var painel = await _painelApp.GetById(id);
            if (painel.PossuiErro)
                return BadRequest(painel);

            return Ok(painel);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PainelViewModel painelViewModel)
        {
            var painel = await _painelApp.Update(painelViewModel);
            if (painel.PossuiErro)
                return BadRequest(painel);

            return Ok(painel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var painelCreditCard = await _painelApp.DeleteById(id);
            if (painelCreditCard.PossuiErro)
                return BadRequest(painelCreditCard);

            return Ok(painelCreditCard);
        }
    }
}
