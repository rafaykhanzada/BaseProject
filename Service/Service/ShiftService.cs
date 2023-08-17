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
    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Shift> _logger;
        private ResultModel _resultModel;

        public ShiftService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Shift> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(ShiftDTO model)
        {
            try
            {
                var data = _mapper.Map<Shift>(model);
                if(data.Id == 0) 
                {
                    data.ShiftCode = GetNextCode();
                    var result = _unitOfWork.ShiftRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.ShiftRepository.UpdateVoid(data);
                }
                
                var list = _unitOfWork.ShiftRepository.GetAll();
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
                var result = _unitOfWork.ShiftRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {

                    _unitOfWork.ShiftRepository.Delete(id);
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
                _resultModel.Data = _mapper.Map<List<ShiftDTO>>(_unitOfWork.ShiftRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<ShiftDTO>(Search);
                _resultModel.Data = _unitOfWork.ShiftRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<ShiftDTO>(_unitOfWork.ShiftRepository.Get(s => s.Id == id).Select(x => new Shift {
                    Id = x.Id,
                    ShiftCode = x.ShiftCode,
                    ShiftName = x.ShiftName,
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
                List<ShiftDTO> data = new();
                data = _mapper.Map<List<ShiftDTO>>(_unitOfWork.ShiftRepository.Get(x => x.DeletedOn == null).Select(x => new Shift
                {
                    Id = x.Id,
                    ShiftCode = x.ShiftCode,
                    ShiftName = x.ShiftName,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.ShiftCode) && s.ShiftCode.Contains(Search) || !String.IsNullOrEmpty(s.ShiftName) && s.ShiftName.Contains(Search)).ToList();
                byte[] content = ExcelExportUtility.ExportToExcel<ShiftDTO>(data);
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
        private string GetNextCode()
        {
            string strCCCode = string.Empty;
            string strPref = "S";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(ShiftCode, PATINDEX('%[0-9]%', ShiftCode),Len(ShiftCode))),0) + 1 As Code FROM tblShift WHERE PATINDEX('%[-]%',ShiftCode) = 2 AND PATINDEX('%[0-9]%', ShiftCode) > 0)D ";
                var dpt = _unitOfWork.ShiftRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "S-0001";
            }
            catch (Exception e)
            {
                strCCCode = "S-0001";
            }
            return strCCCode;
        }

    }
}
