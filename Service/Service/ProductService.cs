using AutoMapper;
using Core.Data.DTO;
using Core.Data.Entities;
using Core.Utilities;
using Microsoft.Extensions.Logging;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly ILogger<Products> _logger;
        private ResultModel _resultModel;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Products> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public ResultModel CreateOrUpdate(ProductDTO model)
        {
            try
            {
                var data = new Products
                {
                    FkPlantId = model.FkPlantId,
                    IsActive = model.IsActive,
                    Product = model.Product,
                    ProductId = model.ProductId,
                    ProductCode =model.ProductCode
                };
                if (data.FkPlantId == null || data.FkPlantId == 0)
                {
                    _resultModel.Success = false;
                    _resultModel.Message = "Plant id is required";
                    return _resultModel;
                }
                if (data.ProductId == 0)
                {
                    data.ProductCode = GetNextCode();
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

        public ResultModel Delete(int id)
        {
            try
            {
                var result = _unitOfWork.ProductRepository.Get(x => x.ProductId == id).FirstOrDefault();
                if (result != null)
                {
                    if (!ValidateForDelete(id))
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

                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<ProductDTO>(Search);
                var data  = _unitOfWork.ProductRepository.PagedList(query, pageIndex, pageSize);
                var list = _mapper.Map<List<ProductDTO>>(data.List);
                foreach (var item in list)
                    if (item.FkPlantId !=null)
                        item.Plant = _unitOfWork.PlantRepository.Get(x => x.PlantId == item.FkPlantId).FirstOrDefault()?.Plant;
                data.List = list;
                _resultModel.Data = data;
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
                _resultModel.Data = _mapper.Map<ProductDTO>(_unitOfWork.ProductRepository.Get(s => s.FkPlantId == id).FirstOrDefault());

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
                List<ProductDTO> data = new();
                data = _mapper.Map<List<ProductDTO>>(_unitOfWork.ProductRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.ProductCode) && s.ProductCode.Contains(Search) || !String.IsNullOrEmpty(s.Product) && s.Product.Contains(Search)).ToList();
                byte[] content = ExcelExportUtility.ExportToExcel<ProductDTO>(data);
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
        private bool ValidateForDelete(int id)
        {
            try
            {
                var data= _unitOfWork.VariantRepository.Get(x => x.FkProductId == id).Any();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                return false;
            }
        }
        private string GetNextCode()
        {
            string strCCCode = string.Empty;
            string strPref = "PR";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(ProductCode, PATINDEX('%[0-9]%', ProductCode),Len(ProductCode))),0) + 1 As Code FROM tblProduct WHERE PATINDEX('%[-]%',ProductCode) = 3 AND PATINDEX('%[0-9]%', ProductCode) > 0)D ";
                var dpt = _unitOfWork.ProductRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "PR-0001";
            }
            catch (Exception e)
            {
                strCCCode = "PR-0001";
            }
            return strCCCode;
        }

    }
}
