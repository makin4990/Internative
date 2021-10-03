using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Aspects.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class RecipesController : ControllerBase
    {
        IRecipeService _recipeService;
        
        public RecipesController(IRecipeService recipeService)
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

        [HttpGet("get-all-recipes")]
        public IActionResult GetAllRecipes(string search=null, int currentPage=1, int pageSize=5)
        {
            if (currentPage == 0)
                currentPage = 1;
            if (pageSize == 0)
                pageSize = 5;
            var result = _recipeService.GetAllRecipes(search, currentPage, pageSize);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all-recipes-by-category-id")]
        public IActionResult GetAllRecipesByCategoryId(int categoryId, int currentPage=1, int pageSize=5)
        {
            if (currentPage == 0)
                currentPage = 1;
            if (pageSize == 0)
                pageSize = 5;
            var result = _recipeService.GetAllRecipesByCategoryId(categoryId, currentPage, pageSize);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-last-recipes")]
        public IActionResult GetLastRecipes()
        {
            var result = _recipeService.GetLastRecipes();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-recipe-by-id")]
        public IActionResult GetRecipeById(int recipeId)
        {
            var result = _recipeService.GetRecipeById(recipeId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-popular-recipes")]
        public IActionResult GetPopularRecipes()
        {
            var result = _recipeService.GetPopularRecipes();
            return result.Success ? Ok(result) : BadRequest(result);

        }

    }
}
