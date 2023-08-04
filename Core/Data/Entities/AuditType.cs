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
using Dapper.Contrib.Extensions;

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
        [IgnoreAttribute]
        public virtual ICollection<Variant> Variants { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
