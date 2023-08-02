using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class RolePermissionVM
    {
        public RHeader header { get; set; }
        public Detail[] detail { get; set; }

    }
    public class RHeader
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
        public bool isActive { get; set; }
    }

    public class Detail
    {
        public string? key { get; set; }
        public string? pcid { get; set; }
        public string? label { get; set; }
        public string data { get; set; }
        public int? create { get; set; } = 0;
        public int? edit { get; set; } = 0;
        public int? view { get; set; } = 0;
        public int? delete { get; set; } = 0;
        public int? post { get; set; } = 0;
        public int? approval { get; set; } = 0;
    }
}
