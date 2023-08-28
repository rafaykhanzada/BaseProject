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
        private readonly ILogger<Models> _logger;
        private ResultModel _resultModel;

        public ModelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Models> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public ResultModel CreateOrUpdate(ModelDTO model)
        {
            try
            {
                var data = _mapper.Map<Models>(model);
                if (data.ModelId == 0)
                    _unitOfWork.ModelRepository.Insert(data);
                else
                    _unitOfWork.ModelRepository.UpdateVoid(data);

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

        public ResultModel Delete(int id)
        {
            try
            {
                var result = _unitOfWork.ModelRepository.Get(x => x.ModelId == id).FirstOrDefault();
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
                var data = _unitOfWork.ModelRepository.PagedList(query, pageIndex, pageSize);
                foreach (var item in _mapper.Map<List<ModelDTO>>(data.List))
                    item.Variant = _unitOfWork.VariantRepository.Get(v => v.VariantId == item.FkVariantId).FirstOrDefault()!.Variant;
                _resultModel.Success = true;
                _resultModel.Data = data;
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
                _resultModel.Data = _mapper.Map<ModelDTO>(_unitOfWork.ModelRepository.Get(s => s.ModelId == id).FirstOrDefault());
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
