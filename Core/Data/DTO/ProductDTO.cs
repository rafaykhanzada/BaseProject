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
        public int ProductId { get; set; }
        public string? Product { get; set; }
        public string? ProductCode { get; set; }
        public int? FkPlantId { get; set; }
        public bool IsActive { get; set; }
    }
}
