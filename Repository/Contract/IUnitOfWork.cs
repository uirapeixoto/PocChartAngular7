using System;

namespace Repository.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void BeginTransaction();
        void BeginCommit();
        void BeginRollback();
    }
}
