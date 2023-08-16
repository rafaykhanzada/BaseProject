using AutoMapper;
using Core.Data.DTO;
using Core.Data.DTOs;
using Core.Data.Entities;
using Core.Utilities;
using Microsoft.AspNetCore.Identity;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork;

namespace Service.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private ResultModel _resultModel;
        private readonly IMapper _mapper;

        public PermissionService(RoleManager<Role> roleManager, IUnitOfWork unitOfWork, ResultModel resultModel, IMapper mapper)
        {
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _resultModel = resultModel;
            _mapper = mapper;
        }


        public async Task<ResultModel> CreatePermissionWithRole(RolePermissionVM model)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(model.header.roleName);
                if (role == null)
                {
                    role = _roleManager.Roles.Where(x => x.Id == model.header.roleId).FirstOrDefault();

                }
                if (role != null)
                {
                    role.Name = model.header.roleName;
                    role.IsActive = model.header.isActive;
                    await _roleManager.UpdateAsync(role);
                }
                else
                {
                    await _roleManager.CreateAsync(new Role { Name = model.header.roleName, IsActive = model.header.isActive });
                    role = await _roleManager.FindByNameAsync(model.header.roleName);
                }


                _unitOfWork.PermissionRepository.Delete(_unitOfWork.PermissionRepository.Get(x => x.RoleId == role.Id));

                _unitOfWork.PermissionRepository.Insert(new Permission()
                {
                    ControlId = 1,
                    Route = "home",
                    IsActive = true,
                    RoleId = role.Id,
                });
                //_unitOfWork.Commit();

                foreach (var item in model.detail)
                {
                    var moduleId = _unitOfWork.MenuRepository.Get(x => x.ControlName == item.data && x.ControlType == "Form").FirstOrDefault().Pcid;
                    var module = _unitOfWork.MenuRepository.Get(x => x.ControlId == moduleId && x.ControlType == "Menu").FirstOrDefault();
                    var form = _unitOfWork.MenuRepository.Get(x => x.ControlName == item.data && x.ControlType == "Form").FirstOrDefault();
                    if (form != null)
                    {
                        var Cntrl = _unitOfWork.MenuRepository.Get(x => x.Pcid == form.ControlId && x.ControlType == "Ctrl");
                        var permission = new List<PermissionVM>();
                        permission.Add(new PermissionVM()
                        {
                            ControlId = module.ControlId,
                            RoleId = role.Id,
                            Route = module.ControlName.ToLower(),
                            IsActive = true
                        });
                        if (item.create == 1)
                        {
                            permission.Add(new PermissionVM()
                            {
                                ControlId = Cntrl.Where(x => x.ControlName == "POST").Select(s => s.ControlId).FirstOrDefault(),
                                RoleId = role.Id,
                                Route = form.ControlName.ToLower(),
                                IsActive = true
                            });
                        }
                        if (item.view == 1)
                        {
                            permission.Add(new PermissionVM()
                            {
                                ControlId = Cntrl.Where(x => x.ControlName == "GET").Select(s => s.ControlId).FirstOrDefault(),
                                RoleId = role.Id,
                                Route = form.ControlName.ToLower(),
                                IsActive = true

                            });
                        }
                        if (item.edit == 1)
                        {
                            permission.Add(new PermissionVM()
                            {
                                ControlId = Cntrl.Where(x => x.ControlName == "PUT").Select(s => s.ControlId).FirstOrDefault(),
                                RoleId = role.Id,
                                Route = form.ControlName.ToLower(),
                                IsActive = true

                            });
                        }
                        if (item.delete == 1)
                        {
                            permission.Add(new PermissionVM()
                            {
                                ControlId = Cntrl.Where(x => x.ControlName == "DELETE").Select(s => s.ControlId).FirstOrDefault(),
                                RoleId = role.Id,
                                IsActive = true,
                                Route = form.ControlName.ToLower(),
                            });
                        }
                        IEnumerable<Permission> en = _mapper.Map<List<Permission>>(permission);

                        _unitOfWork.PermissionRepository.Insert(en);
                        _unitOfWork.Commit();
                    }
                    else
                    {
                        _resultModel.Success = false;
                        _resultModel.Message = "Form Name " + form + " Not Exist in database!";
                        return _resultModel;
                    }
                }
                _resultModel.Success = true;
                _resultModel.Message = "Record Update Successfully";
                return _resultModel;
            }
            catch (NullReferenceException obj)
            {
                _resultModel.Success = true;
                _resultModel.Message = "Some Module Is not in Our Database";
                return _resultModel;
            }
            catch (Exception e)
            {
                _resultModel.Success = true;
                _resultModel.Message = "Invalid or Incomplete Data Exist In database";
                return _resultModel;
            }
            //var permission = _mapper.Map<Permission>(model);
            //var result =  _unitOfWork.PermissionRepository.Insert(permission);
            //return _mapper.Map<PermissionVM>(result);
        }

        public async Task<object> GetsPermissionbyRoleAsync(string roleName)
        {
            try
            {
                var user_role = await _roleManager.FindByNameAsync(roleName);
                if (user_role != null)
                {
                    var control_ids = _unitOfWork.PermissionRepository.Get(p => p.RoleId == user_role.Id && p.IsActive).Select(s => s.ControlId);
                    if (control_ids.Count() > 0)
                    {
                        var FormIds = _unitOfWork.MenuRepository.Get(x => control_ids.Contains(x.ControlId) && x.ControlType == "Ctrl").Select(d => d.Pcid).Distinct().ToList();
                        var Cntrl = _unitOfWork.MenuRepository.Get(x => control_ids.Contains(x.ControlId) && x.ControlType == "Ctrl").ToList();
                        return _unitOfWork.MenuRepository.Get(x => FormIds.Contains(x.ControlId) && x.ControlType == "Form" && x.IsMenu == true).Select(c => new Detail
                        {
                            label = c.ControlName,
                            key = c.ControlId.ToString(),
                            data = c.ControlName,
                            pcid = c.Pcid.Value.ToString(),
                            create = Cntrl.Where(x => x.Pcid == c.ControlId && x.ControlType == "Ctrl" && x.ControlName == "POST").FirstOrDefault() != null ? 1 : 0,
                            delete = Cntrl.Where(x => x.Pcid == c.ControlId && x.ControlType == "Ctrl" && x.ControlName == "DELETE").FirstOrDefault() != null ? 1 : 0,
                            edit = Cntrl.Where(x => x.Pcid == c.ControlId && x.ControlType == "Ctrl" && x.ControlName == "PUT").FirstOrDefault() != null ? 1 : 0,
                            view = Cntrl.Where(x => x.Pcid == c.ControlId && x.ControlType == "Ctrl" && x.ControlName == "GET").FirstOrDefault() != null ? 1 : 0
                        }).ToList();
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<ResultModel> GetMenuWithAction(string role)
        {
            #region RoleBasePermission
            //var e = _context.Permission.Where(p=>p.IsAllow==true).Include(d=>d.Control).Include(x => x.Role).Where(x=>x.RoleId==x.Role.Id).ToList();
            var user_role = await _roleManager.FindByIdAsync(role);
            var control_ids = _unitOfWork.PermissionRepository.Get(p => p.RoleId == user_role.Id && p.IsActive == true).Select(s => s.ControlId);
            #endregion
            #region Menus
            var sub_menu = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Form");

            var menus = _unitOfWork.MenuRepository.Get(x => x.Pcid == null && x.ControlType == "Menu" && x.IsMenu == true).Select(p => new MenuLookUpVM()
            {
                key = p.ControlId,
                label = p.ControlName,
                data = p.ControlName,
                type = p.ControlType,
                items = _unitOfWork.MenuRepository.Get(s => s.Pcid == p.ControlId).Select(c => new
                {
                    key = c.ControlId,
                    label = c.ControlName,
                    data = c.ControlName,
                    PCID = c.Pcid,
                    create = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Ctrl" && x.Pcid == c.ControlId && control_ids.Contains(x.ControlId) && x.ControlName == "POST").ToList().Count() > 0 ? 1 : 0,
                    edit = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Ctrl" && x.Pcid == c.ControlId && control_ids.Contains(x.ControlId) && x.ControlName == "PUT").ToList().Count() > 0 ? 1 : 0,
                    view = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Ctrl" && x.Pcid == c.ControlId && control_ids.Contains(x.ControlId) && x.ControlName == "GET").ToList().Count() > 0 ? 1 : 0,
                    delete = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Ctrl" && x.Pcid == c.ControlId && control_ids.Contains(x.ControlId) && x.ControlName == "DELETE").ToList().Count() > 0 ? 1 : 0,
                    post = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Ctrl" && x.Pcid == c.ControlId && control_ids.Contains(x.ControlId) && x.ControlName == "DELETE").ToList().Count() > 0 ? 1 : 0,
                    approval = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Ctrl" && x.Pcid == c.ControlId && control_ids.Contains(x.ControlId) && x.ControlName == "DELETE").ToList().Count() > 0 ? 1 : 0,
                }).ToList()
            }).ToList();
            _resultModel.Success = true;
            _resultModel.Data = menus;
            return _resultModel;
            #endregion
        }
        public async Task<ResultModel> GetMenuoutWithAction()
        {
            #region RoleBasePermission           
            var menus = _unitOfWork.MenuRepository.Get(x => x.Pcid == null && x.ControlType == "Menu" && x.IsMenu == true).Select(p => new MenuLookUpVM()
            {
                key = p.ControlId,
                label = p.ControlName,
                data = p.ControlName,
                type = p.ControlType,
                items = _unitOfWork.MenuRepository.Get(s => s.Pcid == p.ControlId).Select(c => new
                {
                    key = c.ControlId,
                    label = c.ControlName,
                    data = c.ControlName,
                    PCID = c.Pcid,
                    create = 0,
                    edit = 0,
                    view = 0,
                    delete = 0,
                    post = 0,
                    approval = 0,
                }).ToList()
            }).ToList();
            _resultModel.Success = true;
            _resultModel.Data = menus;
            return _resultModel;
            #endregion
        }
    }
}
