using Microsoft.EntityFrameworkCore.Storage;
using Repository.Contract;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _entityContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext entityContext)
        {
            _entityContext = entityContext;
        }

        public void Commit()
        {
            _entityContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            _transaction = _entityContext.Database.BeginTransaction();
        }

        public void BeginCommit()
        {
            _transaction.Commit();
        }

        public void BeginRollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _entityContext.Dispose();

            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
