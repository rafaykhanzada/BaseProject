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
    public class AuditorService : IAuditorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Auditor> _logger;
        private ResultModel _resultModel;

        public AuditorService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Auditor> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(AuditorDTO model)
        {
            try
            {
                var data = _mapper.Map<Auditor>(model);
                if(data.Id == 0) 
                    _unitOfWork.AuditorRepository.Insert(data);
                else 
                    _unitOfWork.AuditorRepository.UpdateVoid(data);
                var list = _unitOfWork.AuditorRepository.GetAll();
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
                var result = _unitOfWork.AuditorRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {

                    _unitOfWork.AuditorRepository.Delete(id);
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
                _resultModel.Data = _mapper.Map<List<AuditorDTO>>(_unitOfWork.AuditorRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "": DBUtil.GenerateSearchQuery<Auditor>(Search);
                _resultModel.Data = _unitOfWork.AuditorRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<AuditorDTO>(_unitOfWork.AuditorRepository.Get(s=> s.Id == id).Select(x=> new Auditor {
                    Id = x.Id,
                    EmpNo = x.EmpNo,
                    EmpName = x.EmpName,
                    IsActive = x.IsActive
                } ).FirstOrDefault());

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
                List<AuditorDTO> data = new();
                data = _mapper.Map<List<AuditorDTO>>(_unitOfWork.AuditorRepository.Get(x=>x.DeletedOn == null).Select(x => new Auditor
                {
                    Id = x.Id,
                    EmpNo = x.EmpNo,
                    EmpName = x.EmpName,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => s.EmpName == Search || s.EmpNo == Search).ToList();
                
                byte[] content = ExcelExportUtility.ExportToExcel<AuditorDTO>(data);
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
