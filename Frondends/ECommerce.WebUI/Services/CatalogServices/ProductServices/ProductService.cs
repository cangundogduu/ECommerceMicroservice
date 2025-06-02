using ECommerce.WebUI.DTOs.CatalogDtos.ProductDtos;

namespace ECommerce.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService(HttpClient _client) : IProductService
    {
        public async Task CreateAsync(CreateProductDto createProductDto)
        {
            await _client.PostAsJsonAsync("products", createProductDto);
        }

        public async Task DeleteAsync(string id)
        {
            await _client.DeleteAsync("products/" + id);
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
        }

        public async Task<ResultProductDto> GetByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<ResultProductDto>("products/" + id);
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            await _client.PutAsJsonAsync("products/", updateProductDto);
        }
    }
}
