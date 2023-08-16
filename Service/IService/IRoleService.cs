using Core.Data.DTOs;
using Core.Data.Entities;
using Core.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IRoleService
    {
        ResultModel Get();
        ResultModel Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null);
        Task<ResultModel> Get(string id);
        Task<ResultModel> CreateOrUpdate(RoleVM model);
        Task<ResultModel> RemoveFromRolesAsync(User user, IList<string> roles);
        Task<ResultModel> AddToRolesAsync(User user, IList<string> roles);
        Task<ResultModel> Delete(string id);
    }
}
