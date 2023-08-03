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
    public class AuditType : HasIdDate
    {
        public AuditType()
        {
            Variants = new HashSet<Variant>();
            Checkpoints = new HashSet<Checkpoints>();
        }
        public string? AudTypeCode { get; set; }
        public string? AudTypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Variant> Variants { get; set; }
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
