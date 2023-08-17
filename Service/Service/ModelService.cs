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
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Model> _logger;
        private ResultModel _resultModel;

        public ModelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Model> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(ModelDTO model)
        {
            try
            {
                var data = _mapper.Map<Model>(model);
                if(data.Id == 0) 
                {
                    var result = _unitOfWork.ModelRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.ModelRepository.UpdateVoid(data);
                }
                
                var list = _unitOfWork.ModelRepository.GetAll();
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
                var result = _unitOfWork.ModelRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    _unitOfWork.ModelRepository.Delete(id);
                    _unitOfWork.Commit();
                    _resultModel.Success = true;
                    _resultModel.Message = "Record deleted sucessfully.";
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
                _resultModel.Data = _mapper.Map<List<ModelDTO>>(_unitOfWork.ModelRepository.GetAll().ToList());
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

                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<ModelDTO>(Search);
                _resultModel.Data = _unitOfWork.ModelRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<ModelDTO>(_unitOfWork.ModelRepository.Get(s => s.Id == id).Select(x => new Model{
                    Id = x.Id,
                    ModelCode = x.ModelCode,
                    ModelName = x.ModelName,
                    VariantId = x.VariantId,
                    VariantName = x.VariantName,
                    IsActive = x.IsActive
                }).FirstOrDefault());

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
        public ResultModel Export(string? Search = null)
        {
            try
            {
                List<ModelDTO> data = new();
                data = _mapper.Map<List<ModelDTO>>(_unitOfWork.ModelRepository.Get(x => x.DeletedOn == null).Select(x => new Model
                {
                    Id = x.Id,
                    ModelCode = x.ModelCode,
                    ModelName = x.ModelName,
                    VariantId = x.VariantId,
                    VariantName = x.VariantName,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.ModelCode) && s.ModelCode.Contains(Search) ||!String.IsNullOrEmpty(s.VariantName) && s.VariantName.Contains(Search) || !String.IsNullOrEmpty(s.ModelName) && s.ModelName.Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<ModelDTO>(data);
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
    }
}
