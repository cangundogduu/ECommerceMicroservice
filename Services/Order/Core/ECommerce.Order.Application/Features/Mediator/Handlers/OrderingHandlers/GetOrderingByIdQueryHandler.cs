using ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using ECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler(IRepository<Ordering> _repository) : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);

        return value.Adapt<GetOrderingByIdQueryResult>();
    }
}
