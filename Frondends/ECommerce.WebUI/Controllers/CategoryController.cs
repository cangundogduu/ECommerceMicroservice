using ECommerce.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    [Authorize]
    public class CategoryController(ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllAsync();
            return View(values);
        }
    }
}
