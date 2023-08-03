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
    public class CheckpointsService : ICheckpointsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Checkpoints> _logger;
        private ResultModel _resultModel;

        public CheckpointsService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Checkpoints> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(CheckpointsDTO model)
        {
            try
            {
                var data = _mapper.Map<Checkpoints>(model);
                var result = _unitOfWork.CheckpointsRepository.Insert(data);
                var list = _unitOfWork.CheckpointsRepository.GetAll();
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
                _resultModel.Data = _mapper.Map<List<CheckpointsDTO>>(_unitOfWork.CheckpointsRepository.GetAll().ToList());
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
                _resultModel.Data = _mapper.Map<List<CheckpointsDTO>>(_unitOfWork.CheckpointsRepository.GetAllPaged(pageSize, pageIndex).ToList());
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
                _resultModel.Data = _mapper.Map<CheckpointsDTO>(_unitOfWork.CheckpointsRepository.Get(s => s.Id == id).Select(x => new {
                    Id = x.Id,
                    CPCode = x.CPCode,
                    CPDesc = x.CPDesc,
                    CPOrderNo = x.CPOrderNo,
                    Standard = x.Standard,
                    AudTypeId = x.AudTypeId,
                    AudTypeName = x.AudTypeName,
                    VariantId = x.VariantId,
                    VariantName = x.VariantName,
                    ZoneId = x.ZoneId,
                    ZoneName = x.ZoneName,
                    FGroupId = x.FGroupId,
                    FGroupName = x.FGroupName,
                    CPClassId = x.CPClassId,
                    CPClassName = x.CPClassName,
                    DWeightage = x.DWeightage,
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
    }
}
