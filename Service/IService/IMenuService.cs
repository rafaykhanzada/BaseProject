using Core.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IMenuService
    {
        public Task<object> GetMenu(string roleName);
        Task<List<MenuLookUpVM>> GetMenuWithAction(string roleName);
    }
}
