using Core.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Data.Entities
{
    public class Checkpoints: HasDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckpointId { get; set; }
        public string? Description { get; set; }
        public string? Standard { get; set; }   
        public int? FkVariantId { get; set; }
        public int? FkAuditTypeId { get; set; }
        public int? FkZoneOrStationId { get; set; }
        public int? FkClassId { get; set; }
        public decimal? DefectWeightage { get; set; }
        public int? FkFaultGroupId { get; set; }
        public string? CPCode { get; set; }
        public int OrderNo { get; set; }

        [JsonIgnore]
        [ForeignKey("FkVariantId")]
        public Variants? Variant { get; set; }
        [JsonIgnore]
        [ForeignKey("FkZoneOrStationId")]
        public ZoneOrStations? Zone { get; set; }
        [JsonIgnore]
        [ForeignKey("FkFaultGroupId")]
        public FaultGroups? FaultGroup { get; set; }
        [JsonIgnore]
        [ForeignKey("FkClassId")]
        public CheckpointClasses? CPClass { get; set; }
        [JsonIgnore]
        [ForeignKey("FkAuditTypeId")]
        public AuditTypes? AuditType { get; set; }
    }
}
