using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Common;

namespace Core.Data.Entities
{
    public class Role:IdentityRole
    {
        public Role()
        {
            Permission = new HashSet<Permission>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
