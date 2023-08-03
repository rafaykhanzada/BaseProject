using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class PlantDTO 
    {
        public int Id { get; set; }
        public string? PlantCode { get; set; }
        public string? PlantName { get; set; }
        public bool IsActive { get; set; }
    }
}
