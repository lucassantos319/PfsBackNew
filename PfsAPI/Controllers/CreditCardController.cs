using Microsoft.AspNetCore.Mvc;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/credit-card")]
    public class CreditCardController : ControllerBase
    {
        readonly ICreditCardApp _creditCardApp;
        public CreditCardController(ICreditCardApp creditCardApp)
        {
            _creditCardApp = creditCardApp;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreditCardViewModel creditCardViewModel)
        {
            var creditCard = await _creditCardApp.Create(creditCardViewModel);
            if (creditCard.PossuiErro)
                return BadRequest(creditCard.Erro);

            return Ok(creditCard);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var creditCard = await _creditCardApp.GetById(id);
            if (creditCard.PossuiErro)
                return BadRequest(creditCard);

            return Ok(creditCard);
        }

        [HttpGet("painel/{id}")]
        public async Task<IActionResult> GetByPainelId(Guid painelId)
        {
            var creditCards = await _creditCardApp.GetByPainelId(painelId);
            if (creditCards.PossuiErro)
                return BadRequest(creditCards);

            return Ok(creditCards);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreditCardViewModel creditCardViewModel)
        {
            var creditCard = await _creditCardApp.Update(creditCardViewModel);
            if (creditCard.PossuiErro)
                return BadRequest(creditCard);

            return Ok(creditCard);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var deleteCreditCard = await _creditCardApp.DeleteById(id);
            if (deleteCreditCard.PossuiErro)
                return BadRequest(deleteCreditCard);

            return Ok(deleteCreditCard);
        }
    }
}
