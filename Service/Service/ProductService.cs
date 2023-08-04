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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Product> _logger;
        private ResultModel _resultModel;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Product> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(ProductDTO model)
        {
            try
            {
                var data = _mapper.Map<Product>(model);
                if(data.Id == 0) 
                {
                    var result = _unitOfWork.ProductRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.ProductRepository.UpdateVoid(data);
                }
               
                var list = _unitOfWork.ProductRepository.GetAll();
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
                var result = _unitOfWork.ProductRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    if (ValidateForDelete(id)) 
                    {
                        _unitOfWork.ProductRepository.Delete(id);
                        _unitOfWork.Commit();
                        _resultModel.Success = true;
                        _resultModel.Message = "Record deleted sucessfully.";
                    }
                    else 
                    {
                        _resultModel.Success = false;
                        _resultModel.Message = "Record can't be deleted sucessfully, it is in used.";
                    }

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
                _resultModel.Data = _mapper.Map<List<ProductDTO>>(_unitOfWork.ProductRepository.GetAll().ToList());
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
                _resultModel.Data = _mapper.Map<List<ProductDTO>>(_unitOfWork.ProductRepository.GetAllPaged(pageSize, pageIndex).ToList());
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
                _resultModel.Data = _mapper.Map<ProductDTO>(_unitOfWork.ProductRepository.Get(s => s.Id == id).Select(x => new Product {
                    Id = x.Id,
                    ProductCode = x.ProductCode,
                    ProductName = x.ProductName,
                    PlantId = x.PlantId,
                    PlantName = x.PlantName,
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
        private bool ValidateForDelete(int id)
        {
            bool result = true;
            try
            {
                int cnt = _unitOfWork.VariantRepository.Get(x => x.ProductId == id).Count();
                result = (cnt > 0) ? false : true;

            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}
