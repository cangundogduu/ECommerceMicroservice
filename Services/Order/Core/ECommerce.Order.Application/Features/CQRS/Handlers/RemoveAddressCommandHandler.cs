using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class RemoveAddressCommandHandler(IRepository<Address> _repository)
    {
        public async Task Handle(RemoveAddressCommand command)
        {
            
            await _repository.DeleteAsync(command.Id);
        }
    }
}
