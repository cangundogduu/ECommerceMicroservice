using ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using ECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler(IRepository<Ordering> _repository) : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetOrderingQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingId = x.OrderingId,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice

            }).ToList();


        }
    }
}
