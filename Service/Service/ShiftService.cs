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
    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Shifts> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;

        public ShiftService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Shifts> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public ResultModel CreateOrUpdate(string user, ShiftDTO model)
        {
            var task = "";
            try
            {
                var data = new Shifts
                {
                    Shift = model.Shift,
                    ShiftCode = model.ShiftCode,
                    ShiftId = model.ShiftId!.Value,
                    IsActive = true
                };
                if (data.ShiftId == 0)
                {
                    task = "Create";
                    data.ShiftCode = GetNextCode();
                    var result = _unitOfWork.ShiftRepository.Insert(data);
                }
                else
                {
                    task = "Update";
                    _unitOfWork.ShiftRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.ShiftRepository.GetAll();

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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }

        public async Task<ResultModel> Delete(string user, int id)
        {
            var task = "";
            try
            {
                task = "Delete by ID";

                var result = _unitOfWork.ShiftRepository.Get(x => x.ShiftId == id).FirstOrDefault();
                if (result != null)
                {

                    _unitOfWork.ShiftRepository.Delete(id);
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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "X");
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
                _resultModel.Data = _mapper.Map<List<ShiftDTO>>(_unitOfWork.ShiftRepository.GetAll().ToList());
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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }

        public ResultModel Get(string user, int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var task = "";
            try
            {
                task = "Get";
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<ShiftDTO>(Search);
                _resultModel.Data = _unitOfWork.ShiftRepository.PagedList(query, pageIndex, pageSize);
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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }

        public ResultModel Get(string user, int id)
        {
            var task = "";
            try
            {
                task = "Get by ID";

                _resultModel.Data = _mapper.Map<ShiftDTO>(_unitOfWork.ShiftRepository.Get(s => s.ShiftId == id).FirstOrDefault());

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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }
        public ResultModel Export(string user,string? Search = null)
        {
            var task = "";
            try
            {
                task = "Export";
                List<ShiftDTO> data = new();
                data = _mapper.Map<List<ShiftDTO>>(_unitOfWork.ShiftRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.ShiftCode) && s.ShiftCode.Contains(Search) || !String.IsNullOrEmpty(s.Shift) && s.Shift.Contains(Search)).ToList();
                byte[] content = ExcelExportUtility.ExportToExcel<ShiftDTO>(data);
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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, "{}", "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }
        private string GetNextCode()
        {
            string strCCCode = string.Empty;
            string strPref = "S";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(ShiftCode, PATINDEX('%[0-9]%', ShiftCode),Len(ShiftCode))),0) + 1 As Code FROM tblShift WHERE PATINDEX('%[-]%',ShiftCode) = 2 AND PATINDEX('%[0-9]%', ShiftCode) > 0)D ";
                var dpt = _unitOfWork.ShiftRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "S-0001";
            }
            catch (Exception e)
            {
                strCCCode = "S-0001";
            }
            return strCCCode;
        }

    }
}
