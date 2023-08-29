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
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Category> _logger;
        private ResultModel _resultModel;
        private IAuditLoggerService _auditLoggerService;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Category> logger, ResultModel resultModel, IAuditLoggerService auditLoggerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _auditLoggerService = auditLoggerService;
        }
        public async Task<ResultModel> CreateOrUpdate(string user,CategoryDTO model)
        {
            var task = "";
            try
            {
                var data = _mapper.Map<Category>(model);
                if(data.Id == 0)
                {
                    task = "Create";
                    var result = _unitOfWork.CategoryRepository.Insert(data);
                }
                else
                {
                    task = "Update";
                    _unitOfWork.CategoryRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.CategoryRepository.GetAll();
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

                var result = _unitOfWork.CategoryRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    //if (ValidateForDelete(id)) 
                    //{
                        _unitOfWork.CategoryRepository.Delete(id);
                    _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "I");
                    _unitOfWork.Commit();
                    _resultModel.Success = true;
                        _resultModel.Message = "Record deleted sucessfully.";
                    //}
                    //else 
                    //{
                    //    _resultModel.Success = false;
                    //    _resultModel.Message = "Record can't be deleted sucessfully, it is in used.";
                    //}


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
            try
            {
                _resultModel.Data = _mapper.Map<List<CategoryDTO>>(_unitOfWork.CategoryRepository.GetAll().ToList());
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

        public ResultModel Get(string user,int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            var task = "";
            try
            {
                task = "Get";
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<Category>(Search);
                _resultModel.Data = _unitOfWork.CategoryRepository.PagedList(query, pageIndex, pageSize);
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
                task = "Get";
                _resultModel.Data = _mapper.Map<CategoryDTO>(_unitOfWork.CategoryRepository.Get(x => x.Id == id).Select(s => new Category
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive
                }).FirstOrDefault());
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
                List<CategoryDTO> data = new();
                data = _mapper.Map<List<CategoryDTO>>(_unitOfWork.CategoryRepository.Get(x => x.DeletedOn == null).Select(s => new Category
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => s.Name == Search).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<CategoryDTO>(data);
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
                _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(_resultModel.Data), "X");
                _unitOfWork.Commit();
            }
            return _resultModel;
        }
        //private bool ValidateForDelete(int id)
        //{
        //    bool result = true;
        //    try
        //    {
        //        int cnt = _unitOfWork.EmailRepository.Get(x => x.CategId == id).Count();
        //        result = (cnt > 0) ? false : true;

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return result;
        //}

    }
}
