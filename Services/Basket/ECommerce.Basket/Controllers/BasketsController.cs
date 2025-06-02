using ECommerce.Basket.DTOs;
using ECommerce.Basket.Services.BasketServices;
using ECommerce.Basket.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService _basketService,IUserService _userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var userId = _userService.GetUserId;
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
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = _userService.GetUserId;
            var result = await _basketService.DeleteAsync(userId);
            
            return result ? Ok("Basket deleted successfully.") : BadRequest("Basket delete failed.");
        }
    }
}
