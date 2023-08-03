using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class EmailDTO
    {
        public int? Id { get; set; }
        public string? EmailCode { get; set; }
        public string? EmailName { get; set; }
        public int? CategId { get; set; }
        public string? CategName { get; set; }
        public int? PlantId { get; set; }
        public string? PlantName { get; set; }
        public bool IsActive { get; set; }
    }
}
