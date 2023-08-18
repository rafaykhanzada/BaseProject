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
    public class AuditTypeService : IAuditTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AuditTypes> _logger;
        private ResultModel _resultModel;

        public AuditTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AuditTypes> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }

        public async Task<ResultModel> CreateOrUpdate(AuditTypeDTO model)
        {
            try
            {
                var data = _mapper.Map<AuditTypes>(model);
                if(data.AuditTypeId == 0) 
                {
                    data.AudTypeCode = GetNextCode();
                    var result = _unitOfWork.AuditTypeRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.AuditTypeRepository.UpdateVoid(data);
                }
               
                var list = _unitOfWork.AuditTypeRepository.GetAll();
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
                var result = _unitOfWork.AuditTypeRepository.Get(x => x.AuditTypeId == id).FirstOrDefault();
                if (result != null)
                {
                    if (ValidateForDelete(id))
                    {
                        _unitOfWork.AuditTypeRepository.Delete(id);
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
                _resultModel.Data = _mapper.Map<List<AuditTypeDTO>>(_unitOfWork.AuditTypeRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<AuditTypes>(Search);
                _resultModel.Data = _unitOfWork.AuditTypeRepository.PagedList(query, pageIndex, pageSize); 
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
                _resultModel.Data = _mapper.Map<AuditTypeDTO>(_unitOfWork.AuditTypeRepository.Get(s => s.AuditTypeId == id).Select(x => new AuditTypes {
                    AuditTypeId = x.AuditTypeId,
                    AudTypeCode = x.AudTypeCode,
                    AuditType = x.AuditType,
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
                List<AuditTypeDTO> data = new();
                data  = _mapper.Map<List<AuditTypeDTO>>(_unitOfWork.AuditTypeRepository.Get(x => x.DeletedOn == null).Select(x => new AuditTypes
                {
                    AuditTypeId = x.AuditTypeId,
                    AudTypeCode = x.AudTypeCode,
                    AuditType = x.AuditType,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s =>!String.IsNullOrEmpty(s.AuditType) && s.AuditType.Contains(Search) || !String.IsNullOrEmpty(s.AudTypeCode) && s.AudTypeCode.Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<AuditTypeDTO>(data);
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
                int cnt = _unitOfWork.CheckpointsRepository.Get(x => x.CheckpointId == id).Count();
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
            string strPref = "AT";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(AudTypeCode, PATINDEX('%[0-9]%', AudTypeCode),Len(AudTypeCode))),0) + 1 As Code FROM tblAuditType WHERE PATINDEX('%[-]%',AudTypeCode) = 3 AND PATINDEX('%[0-9]%', AudTypeCode) > 0 )D ";
                var dpt = _unitOfWork.AuditTypeRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "AT-0001";
            }
            catch (Exception e)
            {
                strCCCode = "AT-0001";
            }
            return strCCCode;
        }

    }
}
