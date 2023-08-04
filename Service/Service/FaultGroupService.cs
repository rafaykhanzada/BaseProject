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
        private readonly ILogger<FaultGroup> _logger;
        private ResultModel _resultModel;

        public FaultGroupService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FaultGroup> logger, ResultModel resultModel)
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
                var data = _mapper.Map<FaultGroup>(model);
                if(data.Id == 0) 
                {
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
                var result = _unitOfWork.FaultGroupRepository.Get(x => x.Id == id).FirstOrDefault();
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
                _resultModel.Data = _mapper.Map<List<FaultGroupDTO>>(_unitOfWork.FaultGroupRepository.GetAllPaged(pageSize, pageIndex).ToList());
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
                _resultModel.Data = _mapper.Map<FaultGroupDTO>(_unitOfWork.FaultGroupRepository.Get(s => s.Id == id).Select(x => new FaultGroup {
                    Id = x.Id,
                    FGroupCode = x.FGroupCode,
                    FGroupName = x.FGroupName,
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
                int cnt = _unitOfWork.CheckpointsRepository.Get(x => x.FGroupId == id).Count();
                result = (cnt > 0) ? false : true;

            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
