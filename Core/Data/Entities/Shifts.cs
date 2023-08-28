using Core.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Entities
{
    public class Shifts:HasDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ShiftId { get; set; }
        public string? Shift { get; set; }
        public string? Description { get; set; }
        public string? ShiftCode { get; set; }
    }
}
