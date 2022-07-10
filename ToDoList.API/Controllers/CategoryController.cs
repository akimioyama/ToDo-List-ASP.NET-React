using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Common.Extension;
using Microsoft.AspNetCore.Authorization;
using ToDoList.Application.Serviсes.Interfaces;
using ToDoList.Application.DTO;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Json(_categoryService.GetCategory(id));
        }
        [Authorize]
        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetCategoryListByUserId(int id)
        {
            return Json(_categoryService.GetCategotyListByUserId(id));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCategoryListByJwt()
        {
            var jwt = Request.Headers.GetJwt();
            return Json(_categoryService.GetCategotyListByJwt(jwt));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCategoryByUserJwt(CategoryDTO categoryDTO)
        {
            var jwt = Request.Headers.GetJwt();
            return Json(_categoryService.CreateCategoryByJwt(categoryDTO, jwt));
        }
        [Authorize]
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateCategoryByUserId(CategoryDTO categoryDTO, int userId)
        {
            return Json(_categoryService.CreateCategoryByUserId(categoryDTO, userId));
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeCategory(CategoryDTO categoryDTO)
        {
            return Json(_categoryService.ChangeCategory(categoryDTO));
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Json(_categoryService.DeleteCategory(id));
        }
    }
}
