using ECommerce.Basket.DTOs;
using ECommerce.Basket.Services.BasketServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService _basketService) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasket(string userId)
        {
            var values = await _basketService.GetBasketAsync(userId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            await _basketService.SaveorUpdateAsync(basketDto);
            return Ok("Basket created/updated successfully. ");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteBasket(string userId)
        {
            var result = await _basketService.DeleteAsync(userId);
            
            return result ? Ok("Basket deleted successfully.") : BadRequest("Basket delete failed.");
        }
    }
}
