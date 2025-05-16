using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommand : IRequest
    {
        public string UserId { get; set; }

        [JsonIgnore]
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
