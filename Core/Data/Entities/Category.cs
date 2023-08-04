using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using Dapper.Contrib.Extensions;

namespace Core.Data.Entities
{
    public class Category:HasIdDate
    {
        public Category()
        {
            Emails = new HashSet<Email>();
        }
        public string? Name { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Email> Emails { get; set; }
    }
}
