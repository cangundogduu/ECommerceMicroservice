using ECommerce.Basket.DTOs;
using StackExchange.Redis;
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

            if (existBasket != RedisValue.Null)
            {
                return JsonSerializer.Deserialize<BasketDto>(existBasket);
            }

            return new BasketDto
            {
                UserId = userId,
                BasketItems = new List<BasketItemDto>()
            };

        }

        public async Task SaveorUpdateAsync(BasketDto basketDto)
        {
            await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
        }
    }
}
