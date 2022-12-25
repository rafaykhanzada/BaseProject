using Repository.IRepository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UnitofWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbTransaction _transaction;
        private bool _disposed;
        private ICategoryRepository _categoryRepository;
        public UnitOfWork(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_transaction);

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _transaction?.Connection?.BeginTransaction();
                ResetRepositories();
            }

        }
        private void ResetRepositories()
        {
            _categoryRepository = null;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
                if (_transaction?.Connection != null)
                {
                    _transaction.Connection.Dispose();
                }
            }
            _disposed = true;

        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
