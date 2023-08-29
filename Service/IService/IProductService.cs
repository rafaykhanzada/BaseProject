using Core.Data.DTO;
using Core.Utilities;


namespace Service.IService
{
    public interface IProductService
    {
        public ResultModel Get(string user);
        public ResultModel Get(string user,int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null);
        public ResultModel Get(string user, int id);
        public ResultModel Export(string user, string? Search = null);
        public ResultModel CreateOrUpdate(string user, ProductDTO model);
        public ResultModel Delete(string user, int id);
    }
}
