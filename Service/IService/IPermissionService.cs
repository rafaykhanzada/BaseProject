using Core.Data.DTO;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IPermissionService
    {
        Task<object> GetsPermissionbyRoleAsync(string roleName);
        Task<ResultModel> GetMenuoutWithAction();
        Task<ResultModel> CreatePermissionWithRole(RolePermissionVM model);
        Task<ResultModel> GetMenuWithAction(string role);
    }
}
