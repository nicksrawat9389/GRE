using GRE.Application;
using GRE.Application.Interfaces.Repository.Product;
using GRE.Application.Interfaces.Services.Product;
using GRE.Persistence.Implementations.Repository.Product;
using GRE.Persistence.Implementations.Services.Product;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IProductService,ProductService>();
            return services;
        }
    }
}
