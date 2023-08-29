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
    public class PlantService : IPlantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Plants> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;
        public PlantService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Plants> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public async Task<ResultModel> CreateOrUpdate(string user, PlantDTO model)
        {
            var task = "";
            try
            {
                var data = _mapper.Map<Plants>(model);
                data.IsActive = true;

                if (data.PlantId == 0) 
                {
                    task = "Create";
                    data.Code = GetNextCode();
                    var result = _unitOfWork.PlantRepository.Insert(data);
                }
                else 
                {
                    task = "Update";
                    _unitOfWork.PlantRepository.UpdateVoid(data);
                }
                
                var list = _unitOfWork.PlantRepository.GetAll();
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

        public ResultModel Delete(string user, int id)
        {
            var task = "";
            try
            {
                task = "Delete by ID";
                var result = _unitOfWork.PlantRepository.Get(x => x.PlantId == id).FirstOrDefault();
                if (result != null)
                {
                    if (ValidateForDelete(id))
                    {
                        _unitOfWork.PlantRepository.SoftDelete(result, null);
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
                _resultModel.Data = _mapper.Map<List<PlantDTO>>(_unitOfWork.PlantRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<PlantDTO>(Search);
                _resultModel.Data = _unitOfWork.PlantRepository.PagedList(query, pageIndex, pageSize);
                _resultModel.Success = true;
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                task = "Get Error";

                _logger.LogError("Error:", ex);
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
                _resultModel.Data = _mapper.Map<PlantDTO>(_unitOfWork.PlantRepository.Get(s => s.PlantId == id).FirstOrDefault());
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
                List<PlantDTO> data = new();
                data = _mapper.Map<List<PlantDTO>>(_unitOfWork.PlantRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.Code) && s.Code.Contains(Search) || !String.IsNullOrEmpty(s.Plant) && s.Plant.Contains(Search)).ToList();
                byte[] content = ExcelExportUtility.ExportToExcel<PlantDTO>(data);
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
                int cnt = _unitOfWork.ProductRepository.Get(x => x.FkPlantId == id).Count();
                result = (cnt > 0) ? false : true;

                cnt = _unitOfWork.EmailRepository.Get(x => x.FkPlantId == id).Count();
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
            string strPref = "P";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(PlantCode, PATINDEX('%[0-9]%', PlantCode),Len(PlantCode))),0) + 1 As Code FROM tblPlant WHERE PATINDEX('%[-]%',PlantCode) = 2 AND PATINDEX('%[0-9]%', PlantCode) > 0  )D ";
                var dpt = _unitOfWork.PlantRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "P-0001";
            }
            catch (Exception e)
            {
                strCCCode = "P-0001";
            }
            return strCCCode;
        }

    }
}
