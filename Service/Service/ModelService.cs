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
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Models> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;


        public ModelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Models> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public ResultModel CreateOrUpdate(string user, ModelDTO model)
        {
            var task = "";
            try
            {
                var data = new Models
                {
                    ModelId = model.ModelId,
                    Model = model.Model,
                    Code = model.Code,
                    IsActive = model.IsActive,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    FkVariantId=model.FkVariantId
                };
                if (data.ModelId == 0)
                {
                    task = "Create";
                    _unitOfWork.ModelRepository.Insert(data);

                }
                else
                {
                    task = "Update";
                    _unitOfWork.ModelRepository.UpdateVoid(data);


                }

                var list = _unitOfWork.ModelRepository.GetAll();
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
                var result = _unitOfWork.ModelRepository.Get(x => x.ModelId == id).FirstOrDefault();
                if (result != null)
                {
                    _unitOfWork.ModelRepository.Delete(id);
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
                _resultModel.Data = _mapper.Map<List<ModelDTO>>(_unitOfWork.ModelRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<ModelDTO>(Search);
                var data = _unitOfWork.ModelRepository.PagedList(query, pageIndex, pageSize);
                var list = _mapper.Map<List<ModelDTO>>(data.List);
                foreach (var item in list)
                    item.Variant = _unitOfWork.VariantRepository.Get(v => v.VariantId == item.FkVariantId).FirstOrDefault()!.Variant;
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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(ex.Message ), "X");
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
                _resultModel.Data = _mapper.Map<ModelDTO>(_unitOfWork.ModelRepository.Get(s => s.ModelId == id).FirstOrDefault());
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
                List<ModelDTO> data = new();
                data =_unitOfWork.ModelRepository.Get(x => x.DeletedOn == null).Select(x => new ModelDTO
                {
                    ModelId = x.ModelId,
                    Code = x.Code,
                    Model = x.Model,
                    FkVariantId = x.FkVariantId,
                    Variant = _unitOfWork.VariantRepository.Get(v=>v.VariantId == x.FkVariantId).FirstOrDefault()!.Variant,
                    IsActive = x.IsActive
                }).ToList();
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.Code) && s.Code.Contains(Search) ||!String.IsNullOrEmpty(s.Variant) && s.Variant.Contains(Search) || !String.IsNullOrEmpty(s.Model) && s.Model.Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<ModelDTO>(data);
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
    }
}
