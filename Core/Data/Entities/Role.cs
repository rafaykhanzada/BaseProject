using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Dapper.Contrib.Extensions;

namespace Core.Data.Entities
{
    public class Role:IdentityRole
    {
        public Role()
        {
            Permission = new HashSet<Permission>();
        }
        public bool IsActive { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
