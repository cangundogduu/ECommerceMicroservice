using ECommerce.Basket.DTOs;
using System.Text.Json;

namespace ECommerce.Basket.Services.BasketServices
{
    public class BasketService(RedisService _redisService) : IBasketService
    {
        public async Task<bool> DeleteAsync(string userId)
        {
            var result = await _redisService.GetDb().KeyDeleteAsync(userId);
            return result;

        }

        public async Task<BasketDto> GetBasketAsync(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            return JsonSerializer.Deserialize<BasketDto>(existBasket);
        }

        public async Task SaveorUpdateAsync(BasketDto basketDto)
        {
            await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
        }
    }
}
