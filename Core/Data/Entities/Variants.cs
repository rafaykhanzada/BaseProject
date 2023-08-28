using Core.Data.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;


namespace Core.Data.Entities
{
    public class Variants:HasDate
    {
        public Variants()
        {
            Models = new HashSet<Models>();
            Checkpoints = new HashSet<Checkpoints>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int VariantId { get; set; }
        public string? Variant { get; set; }
        public int? FkProductId { get; set; }
        public string? ProductType { get; set; }
        public int? auditTypeId { get; set; }
        public string? VariantCode { get; set; }
        [JsonIgnore]
        [ForeignKey("FkProductId")]
        public virtual Products? Product { get; set; }
        [JsonIgnore]
        [ForeignKey("auditTypeId")]
        public virtual AuditTypes? AuditType { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Models> Models { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
