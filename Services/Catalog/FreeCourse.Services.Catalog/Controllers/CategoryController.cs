using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly Mapper _mapper;

        public CategoryController(ICategoryService categoryService, Mapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(category);
        }

        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
           var response=  await _categoryService.CreateAsync(categoryDto);
            return CreateActionResultInstance(response);  


        }

    }
}
