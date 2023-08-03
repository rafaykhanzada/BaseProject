using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class VariantDTO
    {
        public int? Id { get; set; }
        public string? VariantCode { get; set; }
        public string? VariantName { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? AudTypeId { get; set; }
        public string? AudTypeName { get; set; }

        public bool IsActive { get; set; }
    }
}
