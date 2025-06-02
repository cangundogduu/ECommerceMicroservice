using ECommerce.WebUI.DTOs.BasketDtos;

namespace ECommerce.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync();

        Task AddBasketItemAsync(BasketItemDto basketItemDto);

        Task SaveBasketAsync(BasketDto basketDto);

        Task<bool> DeleteBasketAsync(string productId);

    }
}
