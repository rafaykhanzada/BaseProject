using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTOs
{
    public partial class PermissionVM
    {
        public int Id { get; set; } = 0;
        public int ControlId { get; set; }
        public string RoleId { get; set; }
        public string Route { get; set; }
        public bool IsActive { get; set; }
    }
}
