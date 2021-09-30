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
    public class IngredientsController : ControllerBase
    {
        IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost("add-ingredient")]
        public IActionResult Add(Ingredient ingredient)
        {
            var result = _ingredientService.Add(ingredient);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update-ingredient")]
        public IActionResult Update(Ingredient ingredient)
        {
            var result = _ingredientService.Update(ingredient);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-ingredient")]
        public IActionResult Delete(Ingredient ingredient)
        {
            var result = _ingredientService.Delete(ingredient);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all-ingredients-byrecipeid")]
        public IActionResult GetAllIngredientsByRecipeId(int reciepeId)
        {
            var result = _ingredientService.GetAllIngredientsByRecipeId(reciepeId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
