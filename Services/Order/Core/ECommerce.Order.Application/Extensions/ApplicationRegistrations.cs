using ECommerce.Order.Application.Features.CQRS.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Order.Application.Extensions
{
    public static class ApplicationRegistrations
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
        }
    }
}
