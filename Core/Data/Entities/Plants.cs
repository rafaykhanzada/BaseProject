using Core.Data.Common;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Entities
{
    public class Plants : HasDate
    {
        public Plants()
        {
            Product = new HashSet<Products>();
            Email = new HashSet<Email>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlantId { get; set; }
        public string? Code { get; set; }
        public string? Plant{ get; set; }
        [IgnoreAttribute]
        [JsonIgnore]
        public virtual ICollection<Products> Product { get; set; }
        [IgnoreAttribute]
        [JsonIgnore]
        public virtual ICollection<Email> Email { get; set; }
    }
}
