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
        public int ModelId { get; set; }
        public string? Model { get; set; }
        public string? Code { get; set; }
        public int? FkVariantId { get; set; }
        public string? Variant { get; set; }
        public bool IsActive { get; set; }
    }
}
