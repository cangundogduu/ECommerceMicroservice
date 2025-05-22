using ECommerce.Message.DTOs;
using ECommerce.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IUserMessageService _userMessageService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _userMessageService.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _userMessageService.GetByIdAsync(id);
            if (value is null)
            {
                return BadRequest("Message not found.");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserMessageDto userMessageDto)
        {
            await _userMessageService.CreateAsync(userMessageDto);
            return Ok("Message created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserMessageDto userMessageDto)
        {
            await _userMessageService.UpdateAsync(id, userMessageDto);
            return Ok("Message updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userMessageService.DeleteAsync(id);
            
            return Ok("Message deleted successfully.");
        }
    }
}
