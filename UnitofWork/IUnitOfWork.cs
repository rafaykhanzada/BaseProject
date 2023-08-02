using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IMenuRepository MenuRepository { get; }
        IPermissionRepository PermissionRepository { get; }

        void Commit();
    }
}
