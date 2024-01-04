using Robo.Domain.Entities;
using Robo.Domain.Interfaces.Repositories;
using Robo.Domain.Interfaces.UOW;

namespace Robo.Infra.Repositories
{
    public class BracoStateRepository : BaseRepository<Braco>, IBracoStateRepository
    {
        public BracoStateRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
