using Microsoft.Extensions.DependencyInjection;
using SCMS.Application.Features.Products.Commands;
using SCMS.Application.Interfaces.Repositories;

namespace SCMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateProductCommand).Assembly);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();

            return services;
        }
    }
}
