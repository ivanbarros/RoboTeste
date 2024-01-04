using Microsoft.Extensions.DependencyInjection;
using Robo.Domain.Interfaces.Repositories;
using Robo.Domain.Interfaces.UOW;
using Robo.Infra.Repositories;
using Robo.Infra.UOW;

namespace Robo.Core.Configurations.DependencyInjection
{
    public static class ConfigureRepository
    {

        public static void ConfigureDependenciesRepositories(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBracoStateRepository, BracoStateRepository>();
        }
    }
}
