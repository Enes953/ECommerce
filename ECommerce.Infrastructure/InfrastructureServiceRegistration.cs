using Core.Security.JWT;
using ECommerce.Application.Abstractions.Storage;
using ECommerce.Application.Abstractions.Storage.Azure;
using ECommerce.Infrastructure.Services;
using ECommerce.Infrastructure.Services.Storage;
using ECommerce.Infrastructure.Services.Storage.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IAzureStorage, AzureStorage>();    
            return services;

        }
        public static IServiceCollection AddStorage<T>(this IServiceCollection services, IConfiguration configuration) where T : Storage,IStorage
        {

            services.AddScoped<IStorage, T>();
            return services;

        }
    }
}



//public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
//                                                               IConfiguration configuration)
//{
//    services.AddDbContext<BaseDbContext>(options =>
//                                             options.UseSqlServer(
//                                                 configuration.GetConnectionString("ECommerceConnectionString")));
//    services.AddScoped<IProductRepository, ProductRepository>();
//    services.AddScoped<ICustomerRepository, CustomerRepository>();
//    services.AddScoped<IOrderRepository, OrderRepository>();
//    return services;
