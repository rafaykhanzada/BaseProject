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
                _resultModel.Data = _mapper.Map<List<ShiftDTO>>(_unitOfWork.ShiftRepository.GetAllPaged(pageSize, pageIndex).ToList());
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

    }
}
