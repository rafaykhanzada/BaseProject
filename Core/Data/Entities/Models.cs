using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Data.Common;
using System.Text.Json.Serialization;

namespace Core.Data.Entities
{
    public class Models: HasDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }
        public string? Model { get; set; }
        public string? Code { get; set; }
        public int? FkVariantId { get; set; }
        [JsonIgnore]
        [ForeignKey("FkVariantId")]
        public Variants? Variant { get; set; }   
    }
  
}
