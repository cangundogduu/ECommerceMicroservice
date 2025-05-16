using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var orderings = await _mediator.Send(new GetOrderingQuery());
             return Ok(orderings);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ordering created");
        }
    }
}
