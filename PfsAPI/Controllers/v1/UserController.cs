using Microsoft.AspNetCore.Mvc;
using PfsDomain.Entities;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers.v1
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersApp _application;
        public UserController(IUsersApp application) 
        {
            _application = application;
        }

        [HttpGet("{id}")]
        [ProducesResponseType<User>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var user = await _application.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] UserViewModel.Create.UserRequest user)
        {
            var createUser = await _application.Create(user);
            if (createUser.PossuiErro)
                return BadRequest(createUser.Erro);

            return CreatedAtAction(nameof(Create), new { id = createUser.Valor.Id });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UserViewModel user)
        {
            var updateUser = await _application.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var deleteTransaction = await _application.DeleteById(id);
            if (deleteTransaction.PossuiErro)
                return BadRequest(deleteTransaction);

            return Ok(deleteTransaction);
        }
    }
}
