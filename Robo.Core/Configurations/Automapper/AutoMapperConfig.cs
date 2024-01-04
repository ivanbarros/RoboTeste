using Microsoft.Extensions.DependencyInjection;

namespace Robo.Core.Configurations.Automapper
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg=>cfg.AddProfile<OrganizationProfile>());
        }
    }
}
