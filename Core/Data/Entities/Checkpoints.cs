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
    public class Checkpoints : HasIdDate
    {
        public string? CPCode { get; set; }
        public string? CPDesc { get; set; }
        public int CPOrderNo { get; set; }
        public string? Standard { get; set; }
        public int? AudTypeId { get; set; }
        public string? AudTypeName { get; set; }
        public int? VariantId { get; set; }
        public string? VariantName { get; set; }
        public string? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public string? FGroupId { get; set; }
        public string? FGroupName { get; set; }
        public string? CPClassId { get; set; }
        public string? CPClassName { get; set; }
        public decimal? DWeightage { get; set; }

        [ForeignKey("Variant")]
        public Variant? Variant { get; set; }

        [ForeignKey("Zone")]
        public Zone? Zone { get; set; }

        [ForeignKey("FaultGroup")]
        public FaultGroup? FaultGroup { get; set; }
        [ForeignKey("CPClass")]
        public CPClass? CPClass { get; set; }
        [ForeignKey("AuditType")]
        public AuditType? AuditType { get; set; }


    }
}
