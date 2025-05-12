using ECommerce.Catalog.DTOs.CategoryDTOs;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.CategoryServices;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();//category dto ya eşitlendi.
            await _categoryService.CreateAsync(category);
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return BadRequest("Category not found");
            }
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = updateCategoryDto.Adapt<Category>();
            await _categoryService.UpdateAsync(category);
            return Ok("Category update successfully. ");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
           
            await _categoryService.DeleteAsync(id);
            return Ok("Category deleted successfully.");
        }
    }
}
