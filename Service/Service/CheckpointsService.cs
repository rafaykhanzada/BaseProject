using AutoMapper;
using Core.Data.DTO;
using Core.Data.Entities;
using Core.Utilities;
using Microsoft.Extensions.Logging;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork;


namespace Service.Service
{
    public class CheckpointsService : ICheckpointsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Checkpoints> _logger;
        private ResultModel _resultModel;

        public CheckpointsService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Checkpoints> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(CheckpointsDTO model)
        {
            try
            {
                var data = _mapper.Map<Checkpoints>(model);
                if(data.Id == 0) 
                {
                    data.CPCode = GetNextCode();
                    var result = _unitOfWork.CheckpointsRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.CheckpointsRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.CheckpointsRepository.GetAll();
                _unitOfWork.Commit();
                _resultModel.Success = true;
                _resultModel.Data = list;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
            }
            return _resultModel;
        }

        public async Task<ResultModel> Delete(int id)
        {
            try
            {
                var result = _unitOfWork.CheckpointsRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {

                    _unitOfWork.CheckpointsRepository.Delete(id);
                    _unitOfWork.Commit();
                    _resultModel.Success = true;
                    _resultModel.Message = "Record deleted sucessfully.";

                }
                else
                {
                    _resultModel.Success = false;
                    _resultModel.Message = "Record not found.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
            }
            return _resultModel;
        }

        public ResultModel Get()
        {
            try
            {
                _resultModel.Data = _mapper.Map<List<CheckpointsDTO>>(_unitOfWork.CheckpointsRepository.GetAll().ToList());
                _resultModel.Success = true;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
            }
            return _resultModel;
        }

        public ResultModel Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            try
            {

                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<CheckpointsDTO>(Search);
                _resultModel.Data = _unitOfWork.CheckpointsRepository.PagedList(query, pageIndex, pageSize);
                _resultModel.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
            }
            return _resultModel;
        }

        public ResultModel Get(int id)
        {
            try
            {
                _resultModel.Data = _mapper.Map<CheckpointsDTO>(_unitOfWork.CheckpointsRepository.Get(s => s.Id == id).Select(x => new Checkpoints {
                    Id = x.Id,
                    CPCode = x.CPCode,
                    CPDesc = x.CPDesc,
                    CPOrderNo = x.CPOrderNo,
                    Standard = x.Standard,
                    AudTypeId = x.AudTypeId,
                    AudTypeName = x.AudTypeName,
                    VariantId = x.VariantId,
                    VariantName = x.VariantName,
                    ZoneId = x.ZoneId,
                    ZoneName = x.ZoneName,
                    FGroupId = x.FGroupId,
                    FGroupName = x.FGroupName,
                    CPClassId = x.CPClassId,
                    CPClassName = x.CPClassName,
                    DWeightage = x.DWeightage,
                    IsActive = x.IsActive
                }).FirstOrDefault());

                return _resultModel;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
            }
            return _resultModel;
        }
        public ResultModel Export(string? Search = null)
        {
            try
            {
                List<CheckpointsDTO> data = new();
                data =  _mapper.Map<List<CheckpointsDTO>>(_unitOfWork.CheckpointsRepository.Get(x => x.DeletedOn == null).Select(x => new Checkpoints
                {
                    Id = x.Id,
                    CPCode = x.CPCode,
                    CPDesc = x.CPDesc,
                    CPOrderNo = x.CPOrderNo,
                    Standard = x.Standard,
                    AudTypeId = x.AudTypeId,
                    AudTypeName = x.AudTypeName,
                    VariantId = x.VariantId,
                    VariantName = x.VariantName,
                    ZoneId = x.ZoneId,
                    ZoneName = x.ZoneName,
                    FGroupId = x.FGroupId,
                    FGroupName = x.FGroupName,
                    CPClassId = x.CPClassId,
                    CPClassName = x.CPClassName,
                    DWeightage = x.DWeightage,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => s.AudTypeName == Search || s.CPCode == Search|| s.CPDesc == Search|| s.CPOrderNo.ToString() == Search|| s.Standard == Search|| s.VariantName == Search|| s.ZoneName == Search|| s.FGroupName == Search|| s.CPClassName == Search|| s.DWeightage.ToString() == Search).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<CheckpointsDTO>(data);
                _resultModel.Success = true;
                _resultModel.Data = content;
                _resultModel.Message = $"Total Items Exported {data.Count}";
                return _resultModel;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
            }
            return _resultModel;
        }

        private string GetNextCode()
        {
            string strCCCode = string.Empty;
            string strPref = "CK";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(CPCode, PATINDEX('%[0-9]%', CPCode),Len(CPCode))),0) + 1 As Code FROM tblCheckpoints WHERE PATINDEX('%[-]%',CPCode) = 3 AND PATINDEX('%[0-9]%', CPCode) > 0)D ";
                var dpt = _unitOfWork.CheckpointsRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "CK-0001";
            }
            catch (Exception e)
            {
                strCCCode = "CK-0001";
            }
            return strCCCode;
        }
    }
}
