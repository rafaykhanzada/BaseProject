using Core.Data.DTO;
using Core.Utilities;

namespace Service.IService
{
    public interface ICategoryService
    {
        public ResultModel Get(string user);
        public ResultModel Get(string user,int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null);
        public ResultModel Get(string user, int id);
        public ResultModel Export(string user, string? Search = null);
        public Task<ResultModel> CreateOrUpdate(string user, CategoryDTO model);
        public Task<ResultModel> Delete(string user,int id);
    }
}
