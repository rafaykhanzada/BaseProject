using Core.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;


namespace Core.Data.Entities
{
    public class Products:HasDate
    {
        public Products()
        {
            Variants = new HashSet<Variants>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; }
        public string? Product { get; set; }
        public string? ProductCode { get; set; }
        public int? FkPlantId { get; set; }
        [ForeignKey("FkPlantId")]
        public virtual Plants? Plant { get; set; }

        [JsonIgnore]
        [IgnoreAttribute]
        public virtual ICollection<Variants> Variants { get; set; }

    }
}
