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
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Category> _logger;
        private ResultModel _resultModel;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Category> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(CategoryDTO model)
        {
            try
            {
                var data = _mapper.Map<Category>(model);
                if(data.Id == 0)
                {
                    var result = _unitOfWork.CategoryRepository.Insert(data);
                }
                else
                {
                    _unitOfWork.CategoryRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.CategoryRepository.GetAll();
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
                var result = _unitOfWork.CategoryRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    //if (ValidateForDelete(id)) 
                    //{
                        _unitOfWork.CategoryRepository.Delete(id);
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

        public ResultModel Get(int pageIndex = 0, int pageSize = int.MaxValue, string? Search = null)
        {
            try
            {
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<Category>(Search);
                _resultModel.Data = _unitOfWork.CategoryRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<CategoryDTO>(_unitOfWork.CategoryRepository.Get(x => x.Id == id).Select(s => new Category
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive
                }).FirstOrDefault());
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
