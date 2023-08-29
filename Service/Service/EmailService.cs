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
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Email> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;


        public EmailService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Email> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public async Task<ResultModel> CreateOrUpdate(string user, EmailDTO model)
        {
            var task = "";
            try
            {
                var data = _mapper.Map<Email>(model);
                if(data.EmailId == 0) 
                {
                    task = "Create";
                    data.EmailCode = GetNextCode();
                    var result = _unitOfWork.EmailRepository.Insert(data);
                }
                else 
                {
                    task = "Update";
                    _unitOfWork.EmailRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.EmailRepository.GetAll();
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

        public async Task<ResultModel> Delete(string user, int id)
        {
            var task = "";
            try
            {
                task = "Delete by ID";
                var result = _unitOfWork.EmailRepository.Get(x => x.EmailId == id).FirstOrDefault();
                if (result != null)
                {
                    _unitOfWork.EmailRepository.Delete(id);
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
                _resultModel.Data = _mapper.Map<List<EmailDTO>>(_unitOfWork.EmailRepository.GetAll().ToList());
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

        public ResultModel Get(string user, int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var task = "";
            try
            {
                task = "Get";
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<EmailDTO>(Search);
                var list = _unitOfWork.EmailRepository.PagedList(query, pageIndex, pageSize);
                var data = _mapper.Map<List<EmailDTO>>(list.List);
                foreach (var item in data)
                    item.PlantName = item.PlantId !=null ? _unitOfWork.PlantRepository.Get(x => x.PlantId == item.PlantId).FirstOrDefault()!.Plant:null;
                list.List = data;
                _resultModel.Success = true;
                _resultModel.Data = list;
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

        public ResultModel Get(string user, int id)
        {
            var task = "";
            try
            {
                task = "Get by ID";
                _resultModel.Data = _mapper.Map<EmailDTO>(_unitOfWork.EmailRepository.Get(s => s.EmailId == id).FirstOrDefault());
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
                List<EmailDTO> data = new();
                data = _mapper.Map<List<EmailDTO>>(_unitOfWork.EmailRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.EmailCode) && s.EmailCode.Contains(Search) || !String.IsNullOrEmpty(s.PlantName) && s.PlantName.Contains(Search) || !String.IsNullOrEmpty(s.Email) && s.Email.Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<EmailDTO>(data);
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
            string strPref = "E";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'\\" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(EmailCode, PATINDEX('%[0-9]%', EmailCode),Len(EmailCode))),0) + 1 As Code FROM tblEmail WHERE PATINDEX('%[-]%',EmailCode) = 2 AND PATINDEX('%[0-9]%', EmailCode) > 0)D ";
                var dpt = _unitOfWork.EmailRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "E-0001";
            }
            catch (Exception e)
            {
                strCCCode = "E-0001";
            }
            return strCCCode;
        }
    }
}
