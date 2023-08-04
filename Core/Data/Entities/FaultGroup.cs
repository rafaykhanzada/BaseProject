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
    public class FaultGroup : HasIdDate
    {
        public FaultGroup()
        {
            Checkpoints = new HashSet<Checkpoints>();
        }
        public string? FGroupCode { get; set; }
        public string? FGroupName { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
