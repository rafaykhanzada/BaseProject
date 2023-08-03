using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


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
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
        [JsonIgnore]
        public virtual ICollection<Email> Emails { get; set; }
    }
}
