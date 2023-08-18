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
                if(data.CheckpointId == 0) 
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
                var result = _unitOfWork.CheckpointsRepository.Get(x => x.CheckpointId == id).FirstOrDefault();
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
                var data = _unitOfWork.CheckpointsRepository.PagedList(query, pageIndex, pageSize);
                var mapperlist = _mapper.Map<List<CheckpointsDTO>>(data.List);
                foreach (var item in mapperlist)
                {
                    item.Variant = _unitOfWork.VariantRepository.Get(x => x.VariantId == item.FkVariantId).FirstOrDefault()!.Variant;
                    item.AuditType = _unitOfWork.AuditTypeRepository.Get(x => x.AuditTypeId == item.FkAuditTypeId).FirstOrDefault()!.AuditType;
                    item.ZoneOrStation = _unitOfWork.ZoneRepository.Get(x => x.ZoneOrStationId == item.FkZoneOrStationId).FirstOrDefault()!.ZoneOrStation;
                    item.Class = _unitOfWork.CPClassRepository.Get(x => x.CheckpointClassId == item.FkClassId).FirstOrDefault()!.Class;
                    item.FaultGroup = _unitOfWork.FaultGroupRepository.Get(x => x.FaultGroupId == item.FkFaultGroupId).FirstOrDefault()!.FaultGroup;
                }
                data.List = mapperlist;
                _resultModel.Data = data;
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
                _resultModel.Data = _mapper.Map<CheckpointsDTO>(_unitOfWork.CheckpointsRepository.Get(s => s.CheckpointId == id).FirstOrDefault());

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
                data =  _mapper.Map<List<CheckpointsDTO>>(_unitOfWork.CheckpointsRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.Description) && s.Description == Search || !String.IsNullOrEmpty(s.CPCode)  && s.CPCode.Contains(Search)|| !String.IsNullOrEmpty(s.Standard) && s.Standard.Contains(Search)|| s.OrderNo.ToString().Contains(Search)).ToList();

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
