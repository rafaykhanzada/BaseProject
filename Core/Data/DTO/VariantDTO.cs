using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class VariantDTO
    {
        public int? VariantId { get; set; }
        public string? Variant { get; set; }
        public int? FkProductId { get; set; }
        public string? ProductType { get; set; }
        public int? auditTypeId { get; set; }
        public string? VariantCode { get; set; }
        public string? VariantName { get; set; }
        public string? ProductName { get; set; }
        public string? AudTypeName { get; set; }

        public bool IsActive { get; set; }
    }
}
