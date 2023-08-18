

using Core.Data.Common;
using Core.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Data.Entities
{
    public class AuditTypes: HasDate
    {
        public AuditTypes()
        {
            Variants = new HashSet<Variants>();
            Checkpoints = new HashSet<Checkpoints>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuditTypeId { get; set; }
        public string? AuditType { get; set; }
        public string? AudTypeCode { get; set; }

        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Variants> Variants { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
