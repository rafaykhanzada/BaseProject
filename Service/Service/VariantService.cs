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
    public class VariantService : IVariantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Variants> _logger;
        private ResultModel _resultModel;

        public VariantService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Variants> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(VariantDTO model)
        {
            try
            {
                var data = _mapper.Map<Variants>(model);
                if(data.VariantId ==0) 
                {
                    data.VariantCode = GetNextCode();
                    var result = _unitOfWork.VariantRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.VariantRepository.UpdateVoid(data);
                }
                
                var list = _unitOfWork.VariantRepository.GetAll();
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
                var result = _unitOfWork.VariantRepository.Get(x => x.VariantId == id).FirstOrDefault();
                if (result != null)
                {
                    if (ValidateForDelete(id))
                    {
                        _unitOfWork.VariantRepository.Delete(id);
                        _unitOfWork.Commit();
                        _resultModel.Success = true;
                        _resultModel.Message = "Record deleted sucessfully.";

                    }
                    else
                    {
                        _resultModel.Success = false;
                        _resultModel.Message = "Record is can't be deleted, it is in used.";
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
                _resultModel.Data = _mapper.Map<List<VariantDTO>>(_unitOfWork.VariantRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<VariantDTO>(Search);
                _resultModel.Data = _unitOfWork.VariantRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<VariantDTO>(_unitOfWork.VariantRepository.Get(s => s.VariantId == id).FirstOrDefault());

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
                List<VariantDTO> data = new();
                data = _mapper.Map<List<VariantDTO>>(_unitOfWork.VariantRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.VariantCode) && s.VariantCode.Contains(Search) || !String.IsNullOrEmpty(s.ProductName) && s.ProductName.Contains(Search)).ToList();
                byte[] content = ExcelExportUtility.ExportToExcel<VariantDTO>(data);
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
