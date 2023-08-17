using AutoMapper;
using Core.Constant;
using Core.Data.DTOs;
using Core.Data.Entities;
using Core.Pagging;
using Core.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnitofWork;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<User> _logger;
        private readonly ResultModel _resultModel;
        private readonly IMapper _mapper;
        private readonly IMenuService _menuService;
        private readonly IPermissionService _permissionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IRoleService _roleService;
        //private readonly ICodeService _codeService;
        private readonly RoleManager<Role> _roleManager;
        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, SignInManager<User> signInManager, ILogger<User> logger, ResultModel resultModel, IMapper mapper, IMenuService menuService, IPermissionService permissionService, IUnitOfWork unitOfWork, IFileService fileService, IRoleService roleService, RoleManager<Role> roleManager)//, ICodeService codeService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _resultModel = resultModel;
            _mapper = mapper;
            _menuService = menuService;
            _permissionService = permissionService;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _roleService = roleService;
            _roleManager = roleManager;
            //_codeService = codeService;
        }

        public async Task<ResultModel> CreateOrUpdate(UserVM model, IHttpContextAccessor httpContext, IFormFile? file)
        {
            try
            {
                String? contextUser = httpContext.HttpContext?.User.Claims.FirstOrDefault()?.Value;
                var data = _mapper.Map<User>(model);
                String? image = "";
                if (file != null)
                    data.profile_pic = await _fileService.UploadFileToS3(file);
                IdentityResult identityResult = new IdentityResult();
                //data.LocationId = null;
                data.CreatedBy = contextUser;
                if (data.Id == null)
                {
                    data.UpdatedOn = DateTime.Now;
                    data.CreatedOn = DateTime.Now;
                    //data.LocationId = model.LocationId;
                    //data.Code = _codeService.GetUserCode();
                    data.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(data, model.Password);
                    if (!result.Succeeded)
                        _resultModel.Message = result.Errors.FirstOrDefault().ToString();
                    _resultModel.Message = "Record Create Successfully.";
                    var roles = await _userManager.GetRolesAsync(data);
                    var ee = await _userManager.AddToRolesAsync(data, model.Roles);
                }
                else
                {
                    //var roles = await _userManager.GetRolesAsync(data);
                    //var result1 = _unitOfWork.RoleRepository.Get(x => roles.Contains(x.Name));
                    var userexist = await _userManager.FindByEmailAsync(model.Email);
                    if (userexist != null)
                    {
                        image = data.profile_pic;
                        data = userexist;
                        userexist.UpdatedOn = DateTime.Now;
                        userexist.profile_pic = file != null ? image : data.profile_pic;
                        //userexist.LocationId = model.LocationId;
                        userexist.IsActive = model.IsActive;
                        userexist.UserType = model.UserType;
                        userexist.AuthType = model.AuthType;
                        userexist.Code = userexist.Code;
                        userexist.UpdatedBy = contextUser;
                        //userexist.Name = model.Username;
                        if (file == null && data.profile_pic != null)
                            data.profile_pic = userexist.profile_pic;
                        if (model.Password != null || model.Password != "null")
                        {
                            var hasher = new PasswordHasher<User>();
                            userexist.PasswordHash = hasher.HashPassword(null, model.Password);
                        }
                        var result = await _userManager.UpdateAsync(userexist);
                        _resultModel.Message = result.Errors.Count() > 0 ? result.Errors.FirstOrDefault().Description : "Record Update Successfully.";
                        if (result.Errors.Count() > 0)
                        {
                            _resultModel.Success = false;
                            return _resultModel;
                        }

                    }
                }
                if (model.Roles != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(data);

                    var rolesToRemove = userRoles.Except(model.Roles).ToArray();
                    var rolesToAdd = model.Roles.Except(userRoles).Distinct().ToArray();

                    if (rolesToRemove.Any())
                    {
                        identityResult = await _userManager.RemoveFromRolesAsync(data, rolesToRemove);
                        if (!identityResult.Succeeded)
                        {
                            _resultModel.Success = false;
                            _resultModel.Message = identityResult.Errors.Select(e => e.Description).ToArray().ToString();
                        }

                    }

                    if (rolesToAdd.Any())
                    {
                        identityResult = await _userManager.AddToRolesAsync(data, rolesToAdd);
                        if (!identityResult.Succeeded)
                        {
                            _resultModel.Success = false;
                            _resultModel.Message = identityResult.Errors.Select(e => e.Description).ToArray().ToString();
                        }
                    }

                }
                _resultModel.Success = true;
                _resultModel.Data = _mapper.Map<UserVM>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:", ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

        public async Task<ResultModel> Delete(string id, IHttpContextAccessor httpContext,string UserId)
        {
            try
            {
                var data = _unitOfWork.UserRepository.Get(x => x.Id == id && x.DeletedOn == null).FirstOrDefault();
                if (data != null)
                {
                    data.DeletedBy = UserId;
                    _unitOfWork.UserRepository.SoftDelete(data, httpContext);
                    _unitOfWork.Commit();
                    _resultModel.Message = "Record Deleted Successfully";
                    _resultModel.Success = true;
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

        public ResultModel GetUserLookup(string? type)
        {
            try
            {
                var data = _unitOfWork.UserRepository.Get(x => x.DeletedOn == null);
                if (data.Count() > 0)
                {
                    if (type != null)
                        data = data.Where(x => !string.IsNullOrEmpty(x.UserType) && x.UserType!.ToLower() == type.ToLower());
                    var result = _mapper.Map<List<UserVM>>(data);
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
                var data = _unitOfWork.UserRepository.Get(x => x.DeletedOn == null);
                if (data.Count() > 0)
                {
                    Search = Search?.ToUpper();
                    if (!string.IsNullOrWhiteSpace(Search))
                        data = data.Where(x =>
                        !String.IsNullOrEmpty(x.NormalizedUserName) && x.NormalizedUserName.Contains(Search) ||
                        !String.IsNullOrEmpty(x.NormalizedEmail) && x.NormalizedEmail.Contains(Search) ||
                        !String.IsNullOrEmpty(x.PhoneNumber) && x.PhoneNumber.Contains(Search) ||
                        !String.IsNullOrEmpty(x.UserType) && x.UserType.ToUpper().Contains(Search) ||
                        !String.IsNullOrEmpty(x.AuthType) && x.AuthType.ToUpper().Contains(Search) ||
                        !String.IsNullOrEmpty(x.Code) && x.Code.ToUpper().Contains(Search) ||
                        !String.IsNullOrEmpty(x.Name) && x.Name.ToUpper().Contains(Search)
                        //!String.IsNullOrEmpty(x.Designation) && x.Designation.ToUpper().Contains(Search)
                        );
                    var records = new PagedList<UserVM>(_mapper.Map<List<UserVM>>(data.OrderByDescending(x => x.CreatedOn).ToList()), pageIndex, pageSize);
                    //foreach (var item in records)
                    //{
                    //    item.DepartmentName = _unitOfWork.DepartmentRepository.Get(x => x.Id == item.DepartmentId).FirstOrDefault()?.Name;
                    //    item.LocationName = _unitOfWork.LocationRepository.Get(x => x.Id == item.LocationId)?.FirstOrDefault().Name;
                    //}
                    _resultModel.Success = true;
                    _resultModel.Data = new ListModel(records, data.Count());

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
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var data = _mapper.Map<UserVM>(user);
                    //data.DepartmentName = _unitOfWork.DepartmentRepository.Get(x => x.Id == data.DepartmentId).Count() > 0 ? _unitOfWork.DepartmentRepository.Get(x => x.Id == data.DepartmentId).FirstOrDefault().Name : null;
                    //data.LocationName = _unitOfWork.LocationRepository.Get(x => x.Id == data.LocationId).Count() > 0 ? _unitOfWork.LocationRepository.Get(x => x.Id == data.LocationId).FirstOrDefault().Name : null;
                    data.Roles = await _userManager.GetRolesAsync(user);
                    _resultModel.Success = true;
                    _resultModel.Data = data;
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

        public async Task<ResultModel> Login(LoginVM model)
        {
            try
            {
                string userName = string.Empty;
                User user = null;
                UserVM uservm = new UserVM();
                if (model.Email.Contains("@"))
                {
                    user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        userName = user.UserName;
                        user = await _userManager.FindByNameAsync(userName);
                    }
                    else
                    {
                        userName = model.Email;
                        user = await _userManager.FindByEmailAsync(userName);

                    }
                }
                else
                    userName = model.Email;
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in." + model.Email);
                    user.Token = AuthUtil.GenerateToken(userName);
                    user.TokenExpireOn = DateTime.Now.AddDays(1);
                    user.UpdatedOn = DateTime.Now;
                    await _userManager.UpdateAsync(user);
                    uservm.Roles = await _userManager.GetRolesAsync(user);
                    var menu = uservm.Roles.Count > 0 ? await _menuService.GetMenu(uservm.Roles.FirstOrDefault()) : null;
                    var permission = uservm.Roles.Count > 0 ? await _permissionService.GetsPermissionbyRoleAsync(uservm.Roles.FirstOrDefault()) : null;
                    uservm = _mapper.Map<UserVM>(user);

                    _resultModel.Message = "User Login Successfully.";
                    _resultModel.Success = true;
                    _resultModel.Data = new
                    {
                        UserData = uservm,
                        Menu = menu,
                        Permission = permission,
                    };
                }
                else
                {
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning(MessageString.LockError + userName);
                        _resultModel.Success = false;
                        _resultModel.Message = MessageString.LockError;
                    }
                    else
                    {
                        _logger.LogError(MessageString.InvalidLogin + userName);
                        _resultModel.Success = false;
                        _resultModel.Message = MessageString.InvalidLogin;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(MessageString.ServerError, ex);
                _resultModel.Success = false;
                _resultModel.Message = MessageString.ServerError;
            }
            return _resultModel;
        }

    }
}
