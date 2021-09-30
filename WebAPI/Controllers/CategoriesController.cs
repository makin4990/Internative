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
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add-category")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("updated-category")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-category")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get-category-byid")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var result = _categoryService.GetCategoryById(categoryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories(int currentPage, int pageSize)
        {
            if (currentPage == 0)
                currentPage = 1;
            if (pageSize == 0)
                pageSize = 5;
            var result = _categoryService.GetAllCategory(currentPage,pageSize);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
