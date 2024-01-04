using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Robo.Core.Configurations.Mediator
{
    public static class CQRS
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Robo.Infra");
            services.AddMediatR(assembly);
        }
    }
}
