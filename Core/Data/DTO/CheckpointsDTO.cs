using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class CheckpointsDTO
    {
        public int? CheckpointId { get; set; }
        public string? Description { get; set; }
        public string? Standard { get; set; }
        public int? FkVariantId { get; set; }
        public string? Variant { get; set; }
        public int? FkAuditTypeId { get; set; }
        public string? AuditType { get; set; }
        public int? FkZoneOrStationId { get; set; }
        public string? ZoneOrStation { get; set; }
        public int? FkClassId { get; set; }
        public string? Class { get; set; }
        public decimal? DefectWeightage { get; set; }
        public int? FkFaultGroupId { get; set; }
        public string? FaultGroup { get; set; }
        public string? CPCode { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }

    }
}
