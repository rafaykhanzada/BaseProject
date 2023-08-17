using AutoMapper;
using Core.Data.DTO;
using Core.Data.Entities;
using Core.Utilities;
using Dapper.Contrib.Extensions;
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
    public class ZoneService : IZoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Zone> _logger;
        private ResultModel _resultModel;

        public ZoneService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Zone> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(ZoneDTO model)
        {
            try
            {
                var data = _mapper.Map<Zone>(model);
                if (data.Id == 0) 
                {
                    data.ZoneCode = GetNextCode();
                    var result =  _unitOfWork.ZoneRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.ZoneRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.ZoneRepository.GetAll();
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
                
                var result = _unitOfWork.ZoneRepository.Get(x => x.Id == id).FirstOrDefault();
                if(result != null)
                {
                    if (ValidateForDelete(id)) 
                    {
                        _unitOfWork.ZoneRepository.Delete(id);
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
                _resultModel.Message = "Error While Delete Record";
            }
            return _resultModel;
        }

        public ResultModel Get()
        {
            try
            {
                _resultModel.Data = _mapper.Map<List<ZoneDTO>>(_unitOfWork.ZoneRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<ZoneDTO>(Search);
                _resultModel.Data = _unitOfWork.ZoneRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<ZoneDTO>(_unitOfWork.ZoneRepository.Get(s => s.Id == id).Select(x => new Zone{
                    Id = x.Id,
                    ZoneCode = x.ZoneCode,
                    ZoneName = x.ZoneName,
                    IsStation = x.IsStation,
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
                List<ZoneDTO> data = new();
                data = _mapper.Map<List<ZoneDTO>>(_unitOfWork.ZoneRepository.Get(x => x.DeletedOn == null).Select(x => new Zone
                {
                    Id = x.Id,
                    ZoneCode = x.ZoneCode,
                    ZoneName = x.ZoneName,
                    IsStation = x.IsStation,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.ZoneCode) && s.ZoneCode.Contains(Search) || !String.IsNullOrEmpty(s.ZoneName) && s.ZoneName.Contains(Search)).ToList();
                byte[] content = ExcelExportUtility.ExportToExcel<ZoneDTO>(data);
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
                int cnt = _unitOfWork.CheckpointsRepository.Get(x => x.ZoneId == id).Count();
                result = (cnt > 0) ? false : true;

            }
            catch(Exception ex)
            {

            }
            return result;
        }
        private string GetNextCode()
        {
            string strCCCode = string.Empty;
            string strPref = "S";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(ZoneCode, PATINDEX('%[0-9]%', ZoneCode),Len(ZoneCode))),0) + 1 As Code FROM tblZone WHERE PATINDEX('%[-]%',ZoneCode) = 2 AND PATINDEX('%[0-9]%', ZoneCode) > 0)D ";
                var dpt = _unitOfWork.ZoneRepository.FreeDynamicQuery(sqlQuery);

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
