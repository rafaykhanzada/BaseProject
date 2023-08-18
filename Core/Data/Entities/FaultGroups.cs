using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using Core.Data.Common;

namespace Core.Data.Entities
{
    public class FaultGroups : FG
    {
        public FaultGroups()
        {
            Checkpoints = new HashSet<Checkpoints>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FaultGroupId { get; set; }
        public string? FaultGroup { get; set; }
        public string? FGroupCode { get; set; }
        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Checkpoints> Checkpoints { get; set; }
    }
    public partial class FG: HasDate
    {

    }
}
