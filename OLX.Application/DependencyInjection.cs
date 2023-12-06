using Microsoft.Extensions.DependencyInjection;
using OLX.Application.Interfaces;
using OLX.Application.Services;

namespace OLX.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISellService, SellService>();
            services.AddScoped<IBuyService, BuyService>();

            return services;
        }
    }
}
