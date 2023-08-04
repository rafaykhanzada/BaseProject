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
    public class Email : HasIdDate
    {
        public string? EmailCode { get; set; }
        public string? EmailName { get; set; }
        public int? CategId { get; set; }
        public string? CategName { get; set; }
        public int? PlantId { get; set; }
        public string? PlantName { get; set; }

        [ForeignKey("PlantId")]
        public Plant? Plant { get; set; }

        [ForeignKey("CategId")]
        public Category? Category { get; set; }
    }
}
