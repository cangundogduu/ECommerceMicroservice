using ECommerce.Message.Context;
using ECommerce.Message.DTOs;
using ECommerce.Message.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Message.Services
{
    public class UserMessageService(AppDbContext _context) : IUserMessageService
    {
        public async Task CreateAsync(CreateUserMessageDto userMessageDto)
        {
            var message = userMessageDto.Adapt<UserMessage>();
            await _context.UserMessages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var message = await _context.UserMessages.FindAsync(id);
            _context.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultUserMessageDto>> GetAllAsync()
        {
            var values = await _context.UserMessages.AsNoTracking().ToListAsync();
            return values.Adapt<List<ResultUserMessageDto>>();

        }

        public async Task<ResultUserMessageDto> GetByIdAsync(int id)
        {
            var value = await _context.UserMessages.FindAsync(id);
            return value.Adapt<ResultUserMessageDto>();

        }

        public async Task UpdateAsync(int id,UpdateUserMessageDto userMessageDto)
        {
            var message = await _context.UserMessages.FindAsync(id);
            if(message is null)
            {
                throw new Exception("Message not found");
            }

            message.NameSurname = userMessageDto.NameSurname;
            message.Email = userMessageDto.Email;
            message.Subject = userMessageDto.Subject;
            message.MessageBody = userMessageDto.MessageBody;
            message.IsRead = userMessageDto.IsRead;

            _context.Update(message);
            await _context.SaveChangesAsync();
        }
    }
}
