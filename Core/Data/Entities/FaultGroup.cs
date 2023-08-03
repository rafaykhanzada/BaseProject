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
    public class FaultGroup : HasIdDate
    {
        public FaultGroup()
        {
            Checkpoints = new HashSet<Checkpoints>();
        }
        public string? FGroupCode { get; set; }
        public string? FGroupName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
