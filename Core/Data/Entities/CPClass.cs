using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Core.Data.Entities
{
    public class CPClass : HasIdDate
    {
        public CPClass() 
        {
            Checkpoints = new HashSet<Checkpoints>();
        }
        public string? CPClassCode { get; set; }
        public string? CPClassName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
}
