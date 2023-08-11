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
    public class Plant : HasIdDate
    {
        public Plant()
        {
            Products = new HashSet<Product>();
            Emails = new HashSet<Email>();
        }
        public string? PlantCode { get; set; }
        public string? PlantName { get; set; }
        [IgnoreAttribute]
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
        [IgnoreAttribute]
        [JsonIgnore]
        public virtual ICollection<Email> Emails { get; set; }
    }
}
