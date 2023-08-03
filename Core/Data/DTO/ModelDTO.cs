using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class ModelDTO
    {
        public int Id { get; set; }
        public string? ModelCode { get; set; }
        public string? ModelName { get; set; }
        public int? VariantId { get; set; }
        public string? VariantName { get; set; }
        public bool IsActive { get; set; }
    }
}
