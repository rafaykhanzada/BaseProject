using Core.Data.DTO;
using Core.Utilities;

namespace Service.IService
{
    public interface ICheckpointsService
    {
        public ResultModel Get();
        public ResultModel Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null);
        public ResultModel Get(int id);
        public ResultModel Export(string? Search = null);
        public ResultModel CreateOrUpdate(CheckpointsDTO model);
        public Task<ResultModel> Delete(int id);
    }
}
