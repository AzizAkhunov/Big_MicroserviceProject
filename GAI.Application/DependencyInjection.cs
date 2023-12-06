using GAI.Application.Interfaces;
using GAI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GAI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IYPXService, YPXService>();
            services.AddScoped<IPunishmentService, PunishmentService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
