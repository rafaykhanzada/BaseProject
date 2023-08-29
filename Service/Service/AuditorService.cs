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
    public class AuditorService : IAuditorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Auditors> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;

        public AuditorService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Auditors> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public ResultModel CreateOrUpdate(string user, AuditorDTO model)
        {
            var task = "";
            try
            {
                var data = _mapper.Map<Auditors>(model);

                if (data.Id == 0)
                {
                    task = "Create";
                    _unitOfWork.AuditorRepository.Insert(data);
                }
                else
                {
                    task = "Update";
                    _unitOfWork.AuditorRepository.UpdateVoid(data);
                }
                var list = _unitOfWork.AuditorRepository.GetAll();
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

        public async Task<ResultModel> Delete(string user,int id)
        {
            var task = "";
            try
            {
                task = "Delete by ID";
                var result = _unitOfWork.AuditorRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {

                    _unitOfWork.AuditorRepository.Delete(id);
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
                _resultModel.Data = _mapper.Map<List<AuditorDTO>>(_unitOfWork.AuditorRepository.GetAll().ToList());
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

        public ResultModel Get(string user,int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var task = "";
            try
            {
                task = "Get";
                var query = String.IsNullOrEmpty(Search) ? "": DBUtil.GenerateSearchQuery<Auditors>(Search);
                _resultModel.Data = _unitOfWork.AuditorRepository.PagedList(query, pageIndex, pageSize);
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

        public ResultModel Get(string user,int id)
        {
            var task = "";
            try
            {
                task = "Get by ID";
                _resultModel.Data = _mapper.Map<AuditorDTO>(_unitOfWork.AuditorRepository.Get(s=> s.Id == id).Select(x=> new Auditors {
                    Id = x.Id,
                    Empno = x.Empno,
                    Name = x.Name,
                    IsActive = x.IsActive
                } ).FirstOrDefault());
                if (_resultModel.Data==null)
                {
                    task = "Warning Get by ID";
                    _resultModel.Success = false;
                    _resultModel.Message = "User Not Found";
                    _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "O");
                    _unitOfWork.Commit();
                }
                else { 
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
                List<AuditorDTO> data = new();
                data = _mapper.Map<List<AuditorDTO>>(_unitOfWork.AuditorRepository.Get(x=>x.DeletedOn == null).Select(x => new Auditors
                {
                    Id = x.Id,
                    Empno = x.Empno,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.Name) && s.Name.Contains(Search) || s.Empno.ToString()!.Contains(Search)).ToList();
                
                byte[] content = ExcelExportUtility.ExportToExcel<AuditorDTO>(data);
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


    }
}
