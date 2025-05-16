using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class CreateAddressCommandHandler(IRepository<Address> _repository)
    {
        public async Task Handle(CreateAddressCommand command)
        {
            // Create a new address entity with mapped properties
            var address = command.Adapt<Address>();

            // Save the address to the database
            await _repository.CreateAsync(address);
        }
    }
}
