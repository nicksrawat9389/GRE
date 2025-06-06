using GRE.Application;
using GRE.Application.Interfaces.Repository.Newsletter;
using GRE.Application.Interfaces.Repository.Product;
using GRE.Application.Interfaces.Repository.Store;
using GRE.Application.Interfaces.Repository.User;
using GRE.Application.Interfaces.Services.Newsletter;
using GRE.Application.Interfaces.Services.Product;
using GRE.Application.Interfaces.Services.Store;
using GRE.Application.Interfaces.Services.User;
using GRE.Persistence.Implementations.Repository.Newsletter;
using GRE.Persistence.Implementations.Repository.Product;
using GRE.Persistence.Implementations.Repository.Store;
using GRE.Persistence.Implementations.Repository.User;
using GRE.Persistence.Implementations.Services.Newsletter;
using GRE.Persistence.Implementations.Services.Product;
using GRE.Persistence.Implementations.Services.Store;
using GRE.Persistence.Implementations.Services.User;
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
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<INewsletterRepository,NewsletterRepository>();
            services.AddTransient<INewsletterService, NewsletterService>();
            return services;
        }
    }
}
