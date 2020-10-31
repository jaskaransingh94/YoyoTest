
using Microsoft.Extensions.DependencyInjection;
using YoyoTest.Application.Interfaces;
using YoyoTest.Application.Respository;
using YoyoTest.Domain.Interfaces;
using YoyoTest.Infra.Data.Respository;

namespace YoYoTest.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<IBeepTestRepository, BeepTestRepository>();

            // Infra.Data Layer
            services.AddScoped<IBeepTestService, BeepTestService>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();

        }
    }
}
