using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class CheckpointsDTO
    {
        public int? Id { get; set; }
        public string? CPCode { get; set; }
        public string? CPDesc { get; set; }
        public int CPOrderNo { get; set; }
        public string? Standard { get; set; }
        public int? AudTypeId { get; set; }
        public string? AudTypeName { get; set; }
        public int? VariantId { get; set; }
        public string? VariantName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? FGroupId { get; set; }
        public string? FGroupName { get; set; }
        public int? CPClassId { get; set; }
        public string? CPClassName { get; set; }
        public decimal? DWeightage { get; set; }
        public bool IsActive { get; set; }

    }
}
