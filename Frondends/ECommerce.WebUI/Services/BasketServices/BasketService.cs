using ECommerce.WebUI.DTOs.BasketDtos;

namespace ECommerce.WebUI.Services.BasketServices
{
    public class BasketService(HttpClient _client) : IBasketService
    {
        public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
        {
            var basket = await GetBasketAsync();
            var existProduct = basket.BasketItems.Select(x => x.ProductId == basketItemDto.ProductId).FirstOrDefault();
            if (existProduct)
            {
                var item = basket.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
                item.Quantity += 1;
                await SaveBasketAsync(basket);
            }
            else
            {
                basket.BasketItems.Add(basketItemDto);
                await SaveBasketAsync(basket);
            }


            await SaveBasketAsync(basket);

        }

        public async Task<bool> DeleteBasketAsync(string productId)
        {
            var basket = await GetBasketAsync();

            var deleteItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            basket.BasketItems.Remove(deleteItem);
            await SaveBasketAsync(basket);
            return true;

        }

        public async Task<BasketDto> GetBasketAsync()
        {
            return await _client.GetFromJsonAsync<BasketDto>("baskets");
        }

        public async Task SaveBasketAsync(BasketDto basketDto)
        {
            await _client.PostAsJsonAsync("baskets", basketDto);
        }
    }
}
