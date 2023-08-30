using AutoMapper;
using Core.Constant;
using Core.Data.DTOs;
using Core.Data.Entities;
using Core.Pagging;
using Core.Utilities;
using Microsoft.AspNetCore.Identity;
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
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<Role> _logger;
        private readonly ResultModel _resultModel;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Users> _userManager;

        public RoleService(RoleManager<Role> roleManager, IMapper mapper, ILogger<Role> logger, ResultModel resultModel, IUnitOfWork unitOfWork, UserManager<Users> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
            _resultModel = resultModel;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<ResultModel> AddToRolesAsync(Users user, IList<string> roles)
        {
            try
            {
                var result = await _userManager.AddToRolesAsync(user, roles);
                _resultModel.Success = result.Succeeded;
                _resultModel.Message = "User Role Mapping Success";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

        public async Task<ResultModel> CreateOrUpdate(RoleVM model)
        {
            try
            {
                IdentityResult result;
                var data = _mapper.Map<Role>(model);
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    result = await _roleManager.CreateAsync(data);
                    _resultModel.Message = "Record Create Successfully";
                }
                else
                {
                    result = await _roleManager.UpdateAsync(data);
                    _resultModel.Message = "Record Update Successfully";
                }
                if (result.Succeeded)
                {
                    _resultModel.Success = true;
                    _resultModel.Data = _mapper.Map<RoleVM>(data);
                }
                else
                {
                    _logger.LogWarning("Warning:", MessageString.CreateError);
                    _resultModel.Success = false;
                    _resultModel.Message = MessageString.CreateError;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

        public async Task<ResultModel> Delete(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        _resultModel.Success = true;
                        _resultModel.Message = "Record Deleted Successfully";
                    }
                    else
                    {
                        _resultModel.Success = true;
                        _resultModel.Message = MessageString.DeleteError;
                    }
                }
                else
                {
                    _resultModel.Success = false;
                    _resultModel.Message = MessageString.NotFound;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

        public ResultModel Get()
        {
            try
            {
                var data = _roleManager.Roles.ToList();
                if (data.Count > 0)
                {
                    var result = _mapper.Map<List<RoleVM>>(data);
                    _resultModel.Success = true;
                    _resultModel.Data = new ListModel(result, data.Count());
                }
                else
                {
                    _logger.LogInformation("No Record Found!");
                    _resultModel.Data = new ListModel(list: new List<string>(), count: 0);
                    _resultModel.Success = true;
                    _resultModel.Message = "No Record Found!";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

        public ResultModel Get(int pageIndex = 0, int pageSize = 10, string? Search = null)
        {
            try
            {
                var data = _roleManager.Roles;
                if (data.Count() > 0)
                {
                    if (!string.IsNullOrWhiteSpace(Search))
                        data = data.Where(x =>
                        !String.IsNullOrEmpty(x.NormalizedName) && x.NormalizedName.Contains(Search.ToUpper()));
                    _resultModel.Success = true;
                    _resultModel.Data = new ListModel(new PagedList<RoleVM>(_mapper.Map<List<RoleVM>>(data.OrderBy(x => x.Name).ToList()), pageIndex, pageSize, data.Count()), data.Count());

                }
                else
                {
                    _logger.LogInformation("Warning:", MessageString.NotFound);
                    _resultModel.Data = new ListModel(list: new List<string>(), count: 0);
                    _resultModel.Success = true;
                    _resultModel.Message = MessageString.NotFound;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

        public async Task<ResultModel> Get(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    _resultModel.Success = true;
                    _resultModel.Data = _mapper.Map<RoleVM>(role);
                }
                else
                {
                    _logger.LogInformation("Warning:", MessageString.NotFound);
                    _resultModel.Success = true;
                    _resultModel.Message = MessageString.NotFound;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

        public async Task<ResultModel> RemoveFromRolesAsync(Users user, IList<string> roles)
        {
            try
            {
                var result = await _userManager.RemoveFromRolesAsync(user, roles);
                _resultModel.Success = result.Succeeded;
                _resultModel.Message = "User Role Mapping Remove Success";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

    }
}
