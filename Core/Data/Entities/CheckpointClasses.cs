using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Entities
{
    public class CheckpointClasses: HasDate
    {
        public CheckpointClasses() 
        {
            Checkpoints = new HashSet<Checkpoints>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckpointClassId { get; set; }
        public string? Class { get; set; }
        public string? CPClassCode { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
