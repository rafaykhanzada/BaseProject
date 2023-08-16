using Core.Data.DTOs;
using Core.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService
    {
        Task<ResultModel> Login(LoginVM model);
        ResultModel GetUserLookup(string? typ);
        ResultModel Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null);
        Task<ResultModel> Get(string id);
        Task<ResultModel> CreateOrUpdate(UserVM model, IHttpContextAccessor httpContext, IFormFile? file);
        Task<ResultModel> Delete(string id, IHttpContextAccessor httpContext);
    }
}
