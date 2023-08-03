using Core.Data.DTO;
using Core.Utilities;

namespace Service.IService
{
    public interface IZoneService
    {
        public ResultModel Get();
        public ResultModel Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null);
        public ResultModel Get(int id);
        public Task<ResultModel> CreateOrUpdate(ZoneDTO model);
        public Task<ResultModel> Delete(int id);
    }
}
