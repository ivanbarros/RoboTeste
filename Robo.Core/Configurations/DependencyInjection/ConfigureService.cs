using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Robo.Domain.Interfaces.Services;
using Robo.Domain.Interfaces.Services.Base;
using Robo.Domain.Interfaces.UOW;
using Robo.Infra.Services;
using Robo.Infra.UOW;

namespace Robo.Core.Configurations.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IBracoStateService, BracoStateService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
