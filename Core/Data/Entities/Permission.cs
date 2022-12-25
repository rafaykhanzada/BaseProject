using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class Permission:HasId
    {
        [ForeignKey("Control")]
        public int? ControlId { get; set; }
        [ForeignKey("Role")]
        public string? RoleId { get; set; }
        public string? Route { get; set; }
        public virtual Menu? Control { get; set; } = null!;
        public virtual Role? Role { get; set; } = null!;
    }
}
