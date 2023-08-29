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
    public class VariantService : IVariantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Variants> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;


        public VariantService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Variants> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public async Task<ResultModel> CreateOrUpdate(string user, VariantDTO model)
        {
            var task = "";
            try
            {
                var data = _mapper.Map<Variants>(model);
                if(data.VariantId ==0) 
                {
                    task = "Create";
                    data.VariantCode = GetNextCode();
                    var result = _unitOfWork.VariantRepository.Insert(data);
                }
                else 
                {
                    task = "Update";
                    _unitOfWork.VariantRepository.UpdateVoid(data);
                }
                
                var list = _unitOfWork.VariantRepository.GetAll();
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
                var result = _unitOfWork.VariantRepository.Get(x => x.VariantId == id).FirstOrDefault();
                if (result != null)
                {
                    if (ValidateForDelete(id))
                    {
                        _unitOfWork.VariantRepository.Delete(id);
                        _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");
                        _unitOfWork.Commit();
                        _resultModel.Success = true;
                        _resultModel.Message = "Record deleted sucessfully.";

                    }
                    else
                    {
                        task = "Warning Delete by ID";
                        _resultModel.Success = false;
                        _resultModel.Message = "Record is can't be deleted, it is in used.";
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
                _resultModel.Data = _mapper.Map<List<VariantDTO>>(_unitOfWork.VariantRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<VariantDTO>(Search);
                var data = _unitOfWork.VariantRepository.PagedList(query, pageIndex, pageSize);
                var list = _mapper.Map<List<VariantDTO>>(data.List);
                foreach (var item in list)
                    if (item.auditTypeId != null)
                        item.AudTypeName = _unitOfWork.AuditTypeRepository.Get(x=> x.AuditTypeId==item.auditTypeId).FirstOrDefault()!.AuditType;
                data.List = list;
                _resultModel.Success = true;
                _resultModel.Data = data;
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
                _resultModel.Data = _mapper.Map<VariantDTO>(_unitOfWork.VariantRepository.Get(s => s.VariantId == id).FirstOrDefault());
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
                List<VariantDTO> data = new();
                data = _mapper.Map<List<VariantDTO>>(_unitOfWork.VariantRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.VariantCode) && s.VariantCode.Contains(Search) || !String.IsNullOrEmpty(s.ProductName) && s.ProductName.Contains(Search)).ToList();
                byte[] content = ExcelExportUtility.ExportToExcel<VariantDTO>(data);
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
        private bool ValidateForDelete(int id)
        {
            bool result = true;
            try
            {
                int cnt = _unitOfWork.CheckpointsRepository.Get(x => x.FkVariantId == id).Count();
                result = (cnt > 0) ? false : true;

                cnt = _unitOfWork.ModelRepository.Get(x => x.FkVariantId == id).Count();
                result = (cnt > 0) ? false : true;
            }
            catch (Exception ex)
            {
                result = true;
            }
            return result;
        }
        private string GetNextCode()
        {
            string strCCCode = string.Empty;
            string strPref = "V";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(VariantCode, PATINDEX('%[0-9]%', VariantCode),Len(VariantCode))),0) + 1 As Code FROM tblVariant WHERE PATINDEX('%[-]%',VariantCode) = 2 AND PATINDEX('%[0-9]%', VariantCode) > 0)D ";
                var dpt = _unitOfWork.VariantRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "V-0001";
            }
            catch (Exception e)
            {
                strCCCode = "V-0001";
            }
            return strCCCode;
        }

    }
}
