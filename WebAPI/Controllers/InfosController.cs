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
    public class InfosController : ControllerBase
    {
        IInfoService _infoService;

        public InfosController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpPost("add-info")]
        public IActionResult Add(Info info)
        {
            var result = _infoService.Add(info);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update-info")]
        public IActionResult Update(Info info)
        {
            var result = _infoService.Update(info);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-info")]
        public IActionResult Delete(Info info)
        {
            var result = _infoService.Delete(info);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get-all-info-byreciepeid")]
        public IActionResult GetAllInfoByRecipeId(int recipeId)
        {
            var result = _infoService.GetAllInfoByByRecipeId(recipeId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
