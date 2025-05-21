using ECommerce.Message.DTOs;

namespace ECommerce.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultUserMessageDto>> GetAllAsync();
        Task<ResultUserMessageDto> GetByIdAsync(int id);
        Task CreateAsync(CreateUserMessageDto userMessageDto);
        Task UpdateAsync(int id,UpdateUserMessageDto userMessageDto);
        Task DeleteAsync(int id);
    }
}
