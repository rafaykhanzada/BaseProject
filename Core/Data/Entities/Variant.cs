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
    public class Variant : HasIdDate
    {
        public Variant()
        {
            Models = new HashSet<Model>();
            Checkpoints = new HashSet<Checkpoints>();
        }
        public string? VariantCode { get; set; }
        public string? VariantName { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? AudTypeId { get; set; }
        public string? AudTypeName { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
        [JsonIgnore]
        [ForeignKey("AudTypeId")]
        public virtual AuditType? AuditType { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Model> Models { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
