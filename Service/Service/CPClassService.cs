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
    public class CPClassService : ICPClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckpointClasses> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;


        public CPClassService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CheckpointClasses> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;   
        }
        public async Task<ResultModel> CreateOrUpdate(string user,CPClassDTO model)
        {
            var task = "";
            try
            {
                var data = _mapper.Map<CheckpointClasses>(model);
                if(data.CheckpointClassId == 0)
                {
                    task = "Create";
                    data.CPClassCode = GetNextCode();
                    var result = _unitOfWork.CPClassRepository.Insert(data);
                }
                else
                {
                    task = "Update";
                    _unitOfWork.CPClassRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.CPClassRepository.GetAll();
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
                var result = _unitOfWork.CPClassRepository.Get(x => x.CheckpointClassId == id).FirstOrDefault();
                if (result != null)
                {
                    if (ValidateForDelete(id)) 
                    {
                        _unitOfWork.CPClassRepository.Delete(id);
                        _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");

                        _unitOfWork.Commit();
                        _resultModel.Success = true;
                        _resultModel.Message = "Record deleted sucessfully.";
                    }
                    else 
                    {
                        task = "Warning Delete by ID";
                        _resultModel.Success = false;
                        _resultModel.Message = "Record can't be deleted sucessfully, it is in used.";
                        _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "O");
                        _unitOfWork.Commit();
                    }

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
                _resultModel.Data = _mapper.Map<List<CPClassDTO>>(_unitOfWork.CPClassRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<CPClassDTO>(Search);
                _resultModel.Data = _unitOfWork.CPClassRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<CPClassDTO>(_unitOfWork.CPClassRepository.Get(s => s.CheckpointClassId == id).FirstOrDefault());
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
        public ResultModel Export(string user, string? Search = null)
        {
            var task = "";
            try
            {
                task = "Export";
                List<CPClassDTO> data = new();
                data = _mapper.Map<List<CPClassDTO>>(_unitOfWork.CPClassRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.Class) && s.Class.Contains(Search) || !String.IsNullOrEmpty(s.CPClassCode) && s.CPClassCode.Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<CPClassDTO>(data);
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
        private bool ValidateForDelete(int id)
        {
            bool result = true;
            try
            {
                int cnt = _unitOfWork.CheckpointsRepository.Get(x => x.CheckpointId == id).Count();
                result = (cnt > 0) ? false : true;

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        private string GetNextCode()
        {
            string strCCCode = string.Empty;
            string strPref = "CC";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(CPClassCode, PATINDEX('%[0-9]%', CPClassCode),Len(CPClassCode))),0) + 1 As Code FROM tblCPClass WHERE PATINDEX('%[-]%',CPClassCode) = 3 AND PATINDEX('%[0-9]%', CPClassCode) > 0  )D ";
                var dpt = _unitOfWork.CPClassRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "CD-0001";
            }
            catch (Exception e)
            {
                strCCCode = "CC-0001";
            }
            return strCCCode;
        }
    }
}
