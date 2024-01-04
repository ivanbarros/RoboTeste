using System.Data;

namespace Robo.Domain.Interfaces.UOW
{
    public interface IUnitOfWork : IDisposable
    {

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
