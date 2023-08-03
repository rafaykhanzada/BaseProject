using Core.Data.DTO;
using Core.Utilities;

namespace Service.IService
{
    public interface IShiftService
    {
        public ResultModel Get();
        public ResultModel Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null);
        public ResultModel Get(int id);
        public Task<ResultModel> CreateOrUpdate(ShiftDTO model);
        public Task<ResultModel> Delete(int id);
    }
}
