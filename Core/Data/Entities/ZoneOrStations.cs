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
    public class ZoneOrStations : HasDate
    {
        public ZoneOrStations()
        {
            Checkpoints = new HashSet<Checkpoints>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZoneOrStationId { get; set; }
        public string? ZoneOrStation { get; set; }
        public bool? IsStation { get; set; }
        public string? Code { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints>? Checkpoints { get; set; }
    }
}
