using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;
using Restaurant.Infrastructure.Repositories;

namespace Restaurant.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string configuration)
        {
            services.AddScoped<IShopContext, ShopContext>();
            services.AddScoped<IShopRepository, ShopRepository>();
            return services;
        }
    }
}