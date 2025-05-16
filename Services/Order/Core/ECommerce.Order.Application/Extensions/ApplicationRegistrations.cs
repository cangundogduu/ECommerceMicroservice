using ECommerce.Order.Application.Features.CQRS.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Order.Application.Extensions
{
    public static class ApplicationRegistrations
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();
            
            
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
