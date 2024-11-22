using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SCMS.Application.Behaviors;
using SCMS.Application.Features.Products.Commands;
using SCMS.Application.Mappings;
using SCMS.Domain.Interfaces;
using SCMS.Infrastructure.Repositories;
using System.Reflection;

namespace SCMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR, FluentValidation, Pipeline Behavior
            services.AddMediatR(configuration =>
                 configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Register repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();

            // Register AutoMapper
            services.AddAutoMapper(typeof(ProductProfile).Assembly);

            return services;
        }
    }
}
