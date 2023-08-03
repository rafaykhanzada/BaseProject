using Core.Data.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace Core.Data.Entities
{
    public class Product : HasIdDate
    {
        public Product()
        {
            Variants = new HashSet<Variant>();
        }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }

        public int? PlantId { get; set; }
        public string? PlantName { get; set; }

        [ForeignKey("Plant")]
        public virtual Plant? Plant { get; set; }

        [JsonIgnore]
        public virtual ICollection<Variant> Variants { get; set; }

    }
}
