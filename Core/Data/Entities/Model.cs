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
    public class Model : HasIdDate
    {
        public string? ModelCode { get; set; }
        public string? ModelName { get; set; }
        public int? VariantId { get; set; }
        public string? VariantName { get; set; }

        [ForeignKey("Variant")]
        public Variant? Variant { get; set; }   
    }
}
