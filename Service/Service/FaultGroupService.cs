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
    public class FaultGroupService : IFaultGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<FaultGroups> _logger;
        private ResultModel _resultModel;

        public FaultGroupService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FaultGroups> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(FaultGroupDTO model)
        {
            try
            {
                var data = _mapper.Map<FaultGroups>(model);
                if(data.FaultGroupId == 0) 
                {
                    data.FGroupCode = GetNextCode();
                    var result = _unitOfWork.FaultGroupRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.FaultGroupRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.FaultGroupRepository.GetAll();
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
                var result = _unitOfWork.FaultGroupRepository.Get(x => x.FaultGroupId == id).FirstOrDefault();
                if (result != null)
                {
                    if (ValidateForDelete(id))
                    {
                        _unitOfWork.FaultGroupRepository.Delete(id);
                        _unitOfWork.Commit();
                        _resultModel.Success = true;
                        _resultModel.Message = "Record deleted sucessfully.";
                    }
                    else 
                    {
                        _resultModel.Success = false;
                        _resultModel.Message = "Record can't be deleted, it is in used.";
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
                _resultModel.Data = _mapper.Map<List<FaultGroupDTO>>(_unitOfWork.FaultGroupRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<FaultGroupDTO>(Search);
                _resultModel.Data = _unitOfWork.FaultGroupRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<FaultGroupDTO>(_unitOfWork.FaultGroupRepository.Get(s => s.FaultGroupId == id).FirstOrDefault());

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
                List<FaultGroupDTO> data = new();
                data = _mapper.Map<List<FaultGroupDTO>>(_unitOfWork.FaultGroupRepository.Get(x => x.DeletedOn == null).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.FGroupCode) && s.FGroupCode.Contains(Search) || !String.IsNullOrEmpty(s.FaultGroup) && s.FaultGroup.Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<FaultGroupDTO>(data);
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
                int cnt = _unitOfWork.CheckpointsRepository.Get(x => x.FkFaultGroupId == id).Count();
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
            string strPref = "FG";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(FGroupCode, PATINDEX('%[0-9]%', FGroupCode),Len(FGroupCode))),0) + 1 As Code FROM tblFaultGroup WHERE PATINDEX('%[-]%',FGroupCode) = 3 AND PATINDEX('%[0-9]%', FGroupCode) > 0)D ";
                var dpt = _unitOfWork.FaultGroupRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "FG-0001";
            }
            catch (Exception e)
            {
                strCCCode = "FG-0001";
            }
            return strCCCode;
        }
    }
}
