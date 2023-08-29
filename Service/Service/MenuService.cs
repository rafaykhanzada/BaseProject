using Core.Data.DTO;
using Core.Data.DTOs;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork;

namespace Service.Service
{
    public class MenuService : IMenuService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private IAuditLoggerService _auditLoggerService;


        public MenuService(RoleManager<Role> roleManager, IUnitOfWork unitOfWork, IAuditLoggerService auditLoggerService)
        {
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _auditLoggerService = auditLoggerService;
        }

        public async Task<object> GetMenu(string roleName)
        {
            //var task = "";
            #region RoleBasePermission
            //var e = _context.Permission.Where(p=>p.IsAllow==true).Include(d=>d.Control).Include(x => x.Role).Where(x=>x.RoleId==x.Role.Id).ToList();
            try
            {
                var user_role = await _roleManager.FindByNameAsync(roleName);
                if (user_role != null)
                {

                    var control_ids = _unitOfWork.PermissionRepository.Get(p => p.RoleId == user_role.Id && p.IsActive == true).Select(s => s.ControlId).Distinct().ToList();
                    var menus1 = _unitOfWork.MenuRepository.Get(x => control_ids.Contains(x.ControlId)).Select(d => d.Pcid).Distinct().Where(y => y != null).ToList();
                    var sub_menu = _unitOfWork.MenuRepository.Get(x => x.ControlType == "Form").ToList();
                    #endregion
                    if (control_ids.Count > 0)
                    {
                        //task = "Menu showed";
                        var menus = _unitOfWork.MenuRepository.Get(x => x.Pcid == null && x.ControlType == "Menu" && x.IsMenu == true && control_ids.Contains(x.ControlId)).Select(x => new
                        {
                            key = x.ControlId,
                            name = x.ControlName,
                            noCollapse = false,
                            type = x.ControlType,
                            icon = x.Icon,
                            route = x.Route,
                            collapse = sub_menu.Where(s => s.Pcid == x.ControlId && control_ids.Contains(x.ControlId) && menus1.Contains(s.ControlId)).Where(c => c.IsMenu == true).Select(c => new
                            {
                                key = c.ControlId,
                                name = c.ControlName,
                                route = c.Route,
                                pcid = c.Pcid,
                                sortorder = c.SortOrder
                            }).OrderBy(o => o.sortorder).ToList()
                        }).ToList();
                        //_auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(menus), "I");
                        //_unitOfWork.Commit();
                        return menus;
                    }
                    else
                    {
                        //task = "control null";
                        //_auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(""), "O");
                        //_unitOfWork.Commit();
                        return null;

                    }
                }
                return null;
            }
            catch (Exception e)
            {
                //task = "control error";
                //_auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(""), "X");
                //_unitOfWork.Commit();
                return null;
            }


        }

        public async Task<List<MenuLookUpVM>> GetMenuWithAction(string roleName)
        {
            #region RoleBasePermission
            //var e = _context.Permission.Where(p=>p.IsAllow==true).Include(d=>d.Control).Include(x => x.Role).Where(x=>x.RoleId==x.Role.Id).ToList();
            var user_role = await _roleManager.FindByNameAsync(roleName);
            var control_ids = _unitOfWork.PermissionRepository.Get(p => p.RoleId == user_role.Id && p.IsActive == true).Select(s => s.ControlId);
            #endregion
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
            return menus;
        }
    }
}
