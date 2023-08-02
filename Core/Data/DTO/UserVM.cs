using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTOs
{
    public class UserVM
    {
        public string? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Designation { get; set; }
        public string? UserType { get; set; }
        public string? AuthType { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public string? Token { get; set; }
        public string? ProfileImage { get; set; } = "default_user.jpg";
        public bool IsActive { get; set; }
        public string? FcmToken { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
