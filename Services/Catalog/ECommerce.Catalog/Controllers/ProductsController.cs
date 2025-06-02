using ECommerce.Catalog.DTOs.ProductDTOs;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.ProductServices;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var values = products.Adapt<List<ResultProductDto>>();
            return Ok(values);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            var product = productDto.Adapt<Product>();
            await _productService.CreateAsync(product);
            return Ok("Product create successfully");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }
            return Ok(product);

        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var product = updateProductDto.Adapt<Product>();

            await _productService.UpdateAsync(product);
            
            return Ok("Product update successfully. ");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            if(id == null)
            {
                return BadRequest("Product not found");
            }
            return Ok("Product deleted successfully.");
        }
    }
}
