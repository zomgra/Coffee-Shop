using System.Reflection;
using CoffeeShop.Application.Order.Commands.CancelOrder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(CancelOrderCommand).Assembly);
            });
                return services;
        }
    }
}
