using Microsoft.AspNetCore.Mvc;
using PfsDomain.Interfaces.Applications;
using PfsShared.ViewModels;

namespace PfsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
    public class CategoryController: ControllerBase
    {
        readonly ICategoriesApp _categoriesApp;
        public CategoryController(ICategoriesApp categoriesApp) 
        {
            _categoriesApp = categoriesApp;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriesViewModel categoryViewModel)
        {
            var category = await _categoriesApp.Create(categoryViewModel);
            if ( category.PossuiErro )
                return BadRequest(category.Erro);

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoriesApp.GetById(id);
            if (category.PossuiErro)
                return BadRequest(category);

            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoriesViewModel categoriesViewModel)
        {
            var category = await _categoriesApp.Update(categoriesViewModel);    
            if ( category.PossuiErro)
                return BadRequest(category);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var deleteCategory = await _categoriesApp.DeleteById(id);
            if (deleteCategory.PossuiErro)
                return BadRequest(deleteCategory);

            return Ok(deleteCategory);
        }
    }
}
