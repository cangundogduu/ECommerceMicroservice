using ECommerce.WebUI.DTOs.BasketDtos;
using ECommerce.WebUI.Services.BasketServices;
using ECommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class BasketController(IProductService _productService,IBasketService _basketService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AddToBasket(string id)
        {
            var product = await _productService.GetByIdAsync(id);

            var basketItem = new BasketItemDto
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = 1
            };

            await _basketService.AddBasketItemAsync(basketItem);
            return RedirectToAction("Index");
        }
    }
}
