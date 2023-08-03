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
        IAuditorRepository AuditorRepository { get; }
        IAuditTypeRepository AuditTypeRepository { get; }
        ICheckpointsRepository CheckpointsRepository { get; }
        ICPClassRepository CPClassRepository { get; }
        ICPDeviationRepository CPDeviationRepository { get; }
        IEmailRepository EmailRepository { get; }
        IFaultGroupRepository FaultGroupRepository { get; }
        IModelRepository ModelRepository { get; }
        IPlantRepository PlantRepository { get; }
        IProductRepository ProductRepository { get; }
        IShiftRepository ShiftRepository { get; }
        IVariantRepository VariantRepository { get; }
        IZoneRepository ZoneRepository { get; }

        void Commit();
    }
}
