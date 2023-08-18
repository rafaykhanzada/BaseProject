
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Data.Common;

namespace Core.Data.Entities
{
    public class Email: EmailAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailId { get; set; }
        public string? EmailCode { get; set; }
        public int? FkPlantId { get; set; }
        public string? Category { get; set; }
        [JsonIgnore]
        [ForeignKey("FkPlantId")]
        public Plants? Plant { get; set; }

        //[ForeignKey("CategId")]
        //public Category? Category { get; set; }
    }
    public partial class EmailAddress : HasDate
    {
        public string? Email { get; set; }

    }
}
