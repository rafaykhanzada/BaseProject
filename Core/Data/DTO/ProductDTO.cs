using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public int? PlantId { get; set; }
        public string? PlantName { get; set; }
        public bool IsActive { get; set; }
    }
}
