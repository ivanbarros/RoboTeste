using Microsoft.Extensions.Logging;
using Robo.Domain.Entities;
using Robo.Domain.Interfaces.Repositories;
using Robo.Domain.Interfaces.Services;

namespace Robo.Infra.Services
{
    public class BracoStateService : BaseService<Braco>, IBracoStateService
    {
        public BracoStateService(ILogger<Braco> logger, IBaseRepository<Braco> repository) : base(logger, repository)
        {
        }
    }
}
