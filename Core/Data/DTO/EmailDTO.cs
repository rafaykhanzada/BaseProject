using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class EmailDTO
    {
        public int EmailId { get; set; }
        public string? EmailCode { get; set; }
        public string? Email { get; set; }
        public int? FkPlantId { get; set; }
        public string? Category { get; set; }
        public int? PlantId { get; set; }
        public string? PlantName { get; set; }
        public bool IsActive { get; set; }
    }
}
