using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration conf)
        {
            var connectionStringCoffee = conf.GetConnectionString("Coffee");
   
            services.AddDbContext<CoffeeContext>(c => c.UseSqlServer(connectionStringCoffee));
            services.AddTransient<ICoffeeContext, CoffeeContext>();

            return services;
        }
    }
}
