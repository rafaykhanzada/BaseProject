using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class PlantDTO 
    {
        public int PlantId { get; set; }
        public string? Code { get; set; }
        public string? Plant { get; set; }
        public bool IsActive { get; set; }
    }
}
