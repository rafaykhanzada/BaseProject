using AutoMapper;
using Core.Data.DTO;
using Core.Data.Entities;
using Core.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private IAuditLoggerService _auditLoggerService;

        public CheckpointsService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Checkpoints> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public ResultModel CreateOrUpdate(string user,CheckpointsDTO model)
        {
            var task = "";
            try
            {
                var data = new Checkpoints
                {
                    CheckpointId = model.CheckpointId.Value,
                    FkAuditTypeId = model.FkAuditTypeId,
                    FkFaultGroupId = model.FkFaultGroupId,
                    FkClassId = model.FkClassId,
                    FkVariantId = model.FkVariantId,
                    FkZoneOrStationId = model.FkZoneOrStationId,
                    CPCode = model.CPCode,
                    DefectWeightage = model.DefectWeightage,
                    OrderNo = model.OrderNo,
                    Standard = model.Standard,
                    Description = model.Description
                };
                if (data.CheckpointId == 0)
                {
                    task = "Create";
                    data.CPCode = GetNextCode();
                    var result = _unitOfWork.CheckpointsRepository.Insert(data);
                }
                else
                {
                    task = "Update";
                    _unitOfWork.CheckpointsRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.CheckpointsRepository.GetAll();
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(model), "I");

                _unitOfWork.Commit();
                _resultModel.Success = true;
                _resultModel.Data = list;
            }
            catch (Exception ex)
            {
                task = "Create / Update Error";

                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(ex.Message), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }

        public async Task<ResultModel> Delete(string user,int id)
        {
            var task = "";
            try
            {
                task = "Delete by ID";
                var result = _unitOfWork.CheckpointsRepository.Get(x => x.CheckpointId == id).FirstOrDefault();
                if (result != null)
                {

                    _unitOfWork.CheckpointsRepository.Delete(id);
                    _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");
                    _unitOfWork.Commit();
                    _resultModel.Success = true;
                    _resultModel.Message = "Record deleted sucessfully.";

                }
                else
                {
                    task = "Warning Delete by ID";
                    _resultModel.Success = false;
                    _resultModel.Message = "Record not found.";
                    _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "O");
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                task = "Error Delete by ID";

                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(ex.Message), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }

        public ResultModel Get(string user)
        {
            var task = "";
            try
            {
                task = "Get";
                _resultModel.Data = _mapper.Map<List<CheckpointsDTO>>(_unitOfWork.CheckpointsRepository.GetAll().ToList());
                _resultModel.Success = true;
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");
                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                task = "Get Error";
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(ex.Message), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }

        public ResultModel Get(string user,int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var task = "";
            try
            {
                task = "Get";
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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                task = "Get Error";
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(ex.Message), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }

        public ResultModel Get(string user,int id)
        {
            var task = "";
            try
            {
                task = "Get by ID";
                _resultModel.Data = _mapper.Map<CheckpointsDTO>(_unitOfWork.CheckpointsRepository.Get(s => s.CheckpointId == id).FirstOrDefault());
                if (_resultModel.Data == null)
                {
                    task = "Warning Get by ID";
                    _resultModel.Success = false;
                    _resultModel.Message = "User Not Found";
                    _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "O");
                    _unitOfWork.Commit();
                }
                else
                {
                    _resultModel.Success = true;
                    _resultModel.Message = "User Found";
                    _auditLoggerService.LogTransactionStatus<AuditorDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");
                    _unitOfWork.Commit();
                }
                return _resultModel;
            }
            catch (Exception ex)
            {
                task = "Get by ID Error";

                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(ex.Message), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }
        public ResultModel Export(string user, string? Search = null)
        {
            var task = "";
            try
            {
                task = "Export";
                List<CheckpointsDTO> data = new();
                data =  _mapper.Map<List<CheckpointsDTO>>(_unitOfWork.CheckpointsRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.Description) && s.Description == Search || !String.IsNullOrEmpty(s.CPCode)  && s.CPCode.Contains(Search)|| !String.IsNullOrEmpty(s.Standard) && s.Standard.Contains(Search)|| s.OrderNo.ToString().Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<CheckpointsDTO>(data);
                _resultModel.Success = true;
                _resultModel.Data = content;
                _resultModel.Message = $"Total Items Exported {data.Count}";
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(data), "I");
                _unitOfWork.Commit();
                return _resultModel;
            }
            catch (Exception ex)
            {
                task = "Export Error";
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = "Error While Get Record";
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(ex.Message), "X");
                _unitOfWork.Commit();
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
