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
        private IMenuRepository _menuRepository;
        private IPermissionRepository _permissionRepository;
        private IAuditorRepository _auditorRepository;
        private IAuditTypeRepository _auditTypeRepository;
        private ICheckpointsRepository _checkpointsRepository;
        private ICPClassRepository _cpcClassRepository;
        private ICPDeviationRepository _cPDeviationRepository;
        private IEmailRepository _emailRepository;
        private IFaultGroupRepository _faultGroupRepository;
        private IModelRepository _modelRepository;
        private IPlantRepository _plantRepository;
        private IProductRepository _productRepository;
        private IShiftRepository _shiftRepository;
        private IVariantRepository _variantRepository;
        private IZoneRepository _zoneRepository;
        private IUserRepository _userRepository;
        private IAuditLoggerRepository _auditLoggerRepository;
        public UnitOfWork(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_transaction);
        public IAuditorRepository AuditorRepository => _auditorRepository ??= new AuditorRepository(_transaction);
        public IAuditTypeRepository AuditTypeRepository => _auditTypeRepository ??= new AuditTypeRepository(_transaction);
        public ICheckpointsRepository CheckpointsRepository => _checkpointsRepository ??= new CheckpointsRepository(_transaction);
        public ICPClassRepository CPClassRepository => _cpcClassRepository ??= new CPClassRepository(_transaction);
        public ICPDeviationRepository CPDeviationRepository => _cPDeviationRepository ??= new CPDeviationRepository(_transaction);
        public IEmailRepository EmailRepository => _emailRepository ??= new EmailRepository(_transaction);
        public IFaultGroupRepository FaultGroupRepository => _faultGroupRepository ??= new FaultGroupRepository(_transaction);
        public IModelRepository ModelRepository => _modelRepository ??= new ModelRepository(_transaction);
        public IPlantRepository PlantRepository => _plantRepository ??= new PlantRepository(_transaction);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_transaction);
        public IShiftRepository ShiftRepository => _shiftRepository ??= new ShiftRepository(_transaction);
        public IVariantRepository VariantRepository => _variantRepository ??= new VariantRepository(_transaction);
        public IZoneRepository ZoneRepository => _zoneRepository ??= new ZoneRepository(_transaction);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_transaction);
        public IMenuRepository MenuRepository => _menuRepository ??= new MenuRepository(_transaction);
        public IPermissionRepository PermissionRepository => _permissionRepository ??= new PermissionRepository(_transaction);
        public IAuditLoggerRepository AuditLoggerRepository => _auditLoggerRepository ??= new AuditLoggerRepository(_transaction);
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
            _auditorRepository = null;
            _auditTypeRepository = null;
            _checkpointsRepository = null;
            _cpcClassRepository = null;
            _cPDeviationRepository = null;
            _emailRepository = null;
            _faultGroupRepository = null;
            _modelRepository = null;
            _plantRepository = null;
            _productRepository = null;
            _shiftRepository = null;
            _variantRepository = null;
            _zoneRepository = null;
            _userRepository = null;
            _auditLoggerRepository = null;

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
