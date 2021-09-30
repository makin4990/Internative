using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipsControler : ControllerBase
    {
        IRecipeService _recipeService;
        
        public RecipsControler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost("add-recipe")]
        public IActionResult Add(Recipe recipe)
        {
            var result = _recipeService.Add(recipe);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("updated-recipe")]
        public IActionResult Update(Recipe recipe)
        {
            var result = _recipeService.Update(recipe);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-recipe")]
        public IActionResult Delete(Recipe recipe)
        {
            var result = _recipeService.Delete(recipe);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all-recips")]
        public IActionResult GetAllRecips(string search, int currentPage, int pageSize)
        {
            if (currentPage == 0)
                currentPage = 1;
            if (pageSize == 0)
                pageSize = 5;
           var result = _recipeService.GetAllRecips(search, currentPage, pageSize);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all-recips-by-categoryid")]
        public IActionResult GetAllRecipsByCategoryId(int categoryId, int currentPage, int pageSize)
        {
            if (currentPage == 0)
                currentPage = 1;
            if (pageSize == 0)
                pageSize = 5;
            var result = _recipeService.GetAllRecipsByCategoryId(categoryId, currentPage, pageSize);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-last-recips")]
        public IActionResult GetLastRecips()
        {
            var result = _recipeService.GetLastRecipes();
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
