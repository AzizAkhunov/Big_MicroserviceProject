using Microsoft.Extensions.DependencyInjection;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Application.Services;

namespace YandexTaxi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IScrinService, ScrinService>();

            return services;
        }
    }
}
