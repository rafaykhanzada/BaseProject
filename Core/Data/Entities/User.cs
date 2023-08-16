using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class User:IdentityUser
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? UserType { get; set; }
        public string? AuthType { get; set; }
        public string? profile_pic { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpireOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsActive { get; set; }
        public string? FcmToken { get; set; }
        //public int? LocationId { get; set; }
    }
}
