using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;

public record RemoveOrderingCommand(int Id) : IRequest;


