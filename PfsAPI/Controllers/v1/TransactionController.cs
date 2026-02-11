using Microsoft.AspNetCore.Mvc;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v1/transaction")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionApp _transactionApp;
        public TransactionController(ITransactionApp transactionApp)
        {
            _transactionApp = transactionApp;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionViewModel transactionViewModel)
        {
            var transaction = await _transactionApp.Create(transactionViewModel);
            if (transaction.PossuiErro)
                return BadRequest(transaction.Erro);

            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var transactions = await _transactionApp.GetById(id);
            if (transactions.PossuiErro)
                return BadRequest(transactions);

            return Ok(transactions);
        }

        [HttpGet("painel/{id}")]
        public async Task<IActionResult> GetByPainelId(Guid painelId)
        {
            var transactions = await _transactionApp.GetByPainelId(painelId);
            if (transactions.PossuiErro)
                return BadRequest(transactions);

            return Ok(transactions);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TransactionViewModel transactionViewModel)
        {
            var transaction = await _transactionApp.Update(transactionViewModel);
            if (transaction.PossuiErro)
                return BadRequest(transaction);

            return Ok(transaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var deleteTransaction = await _transactionApp.DeleteById(id);
            if (deleteTransaction.PossuiErro)
                return BadRequest(deleteTransaction);

            return Ok(deleteTransaction);
        }
    }
}
