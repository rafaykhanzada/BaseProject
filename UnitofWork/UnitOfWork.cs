using Repository.IRepository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitofWork
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private IDbTransaction _transaction;
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
            catch (Exception ex)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _transaction.Connection?.Close();
            _transaction.Connection?.Dispose();
            _transaction.Dispose();
        }
    }
}
