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
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Email> _logger;
        private ResultModel _resultModel;

        public EmailService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Email> logger, ResultModel resultModel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
        }
        public async Task<ResultModel> CreateOrUpdate(EmailDTO model)
        {
            try
            {
                var data = _mapper.Map<Email>(model);
                if(data.Id == 0) 
                {
                    data.EmailCode = GetNextCode();
                    var result = _unitOfWork.EmailRepository.Insert(data);
                }
                else 
                {
                    _unitOfWork.EmailRepository.UpdateVoid(data);
                }

                var list = _unitOfWork.EmailRepository.GetAll();
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
                var result = _unitOfWork.EmailRepository.Get(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    _unitOfWork.EmailRepository.Delete(id);
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
                _resultModel.Data = _mapper.Map<List<EmailDTO>>(_unitOfWork.EmailRepository.GetAll().ToList());
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
                var query = String.IsNullOrEmpty(Search) ? "" : DBUtil.GenerateSearchQuery<EmailDTO>(Search);
                _resultModel.Data = _unitOfWork.EmailRepository.PagedList(query, pageIndex, pageSize);
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
                _resultModel.Data = _mapper.Map<EmailDTO>(_unitOfWork.EmailRepository.Get(s => s.Id == id).Select(x => new Email {
                    Id = x.Id,
                    EmailCode = x.EmailCode,
                    EmailName = x.EmailName,
                    CategId = x.CategId,
                    CategName = x.CategName,
                    PlantId = x.PlantId,
                    PlantName = x.PlantName,
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
                List<EmailDTO> data = new();
                data = _mapper.Map<List<EmailDTO>>(_unitOfWork.EmailRepository.Get(x => x.DeletedOn == null).Select(x => new Email
                {
                    Id = x.Id,
                    EmailCode = x.EmailCode,
                    EmailName = x.EmailName,
                    CategId = x.CategId,
                    CategName = x.CategName,
                    PlantId = x.PlantId,
                    PlantName = x.PlantName,
                    IsActive = x.IsActive
                }).ToList());
                if (!String.IsNullOrEmpty(Search))
                    data = data.Where(s => !String.IsNullOrEmpty(s.EmailCode) && s.EmailCode.Contains(Search) || !String.IsNullOrEmpty(s.CategName) && s.CategName.Contains(Search) || !String.IsNullOrEmpty(s.PlantName) && s.PlantName.Contains(Search) || !String.IsNullOrEmpty(s.EmailName) && s.EmailName.Contains(Search)).ToList();

                byte[] content = ExcelExportUtility.ExportToExcel<EmailDTO>(data);
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
            string strPref = "E";
            try
            {
                string sqlQuery = "SELECT FORMAT(Code,'\\" + strPref + "-0000') FROM ";
                sqlQuery += "(SELECT IsNull(MAX(SUBSTRING(EmailCode, PATINDEX('%[0-9]%', EmailCode),Len(EmailCode))),0) + 1 As Code FROM tblEmail WHERE PATINDEX('%[-]%',EmailCode) = 2 AND PATINDEX('%[0-9]%', EmailCode) > 0)D ";
                var dpt = _unitOfWork.EmailRepository.FreeDynamicQuery(sqlQuery);

                strCCCode = (dpt != null) ? ((object[])((System.Collections.Generic.IDictionary<string, object>)dpt).Values)[0].ToString() : "E-0001";
            }
            catch (Exception e)
            {
                strCCCode = "E-0001";
            }
            return strCCCode;
        }
    }
}
