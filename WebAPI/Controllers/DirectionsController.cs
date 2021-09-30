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
    public class DirectionsController : ControllerBase
    {
        IDirectionService _directionService;

        public DirectionsController(IDirectionService directionService)
        {
            _directionService = directionService;
        }

        [HttpPost("add-direction")]
        public IActionResult Add(Direction direction)
        {
            var result = _directionService.Add(direction);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update-direction")]
        public IActionResult Update(Direction direction)
        {
            var result = _directionService.Update(direction);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-direction")]
        public IActionResult Delete(Direction direction)
        {
            var result = _directionService.Delete(direction);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-directions-byrecipeid")]
        public IActionResult GetDirectionByRecipeId(int recipeId)
        {
            var result = _directionService.GetDirectionByRecipeId(recipeId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
