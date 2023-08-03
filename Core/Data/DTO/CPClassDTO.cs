using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class CPClassDTO
    {
        public int Id { get; set; }
        public string? CPClassCode { get; set; }
        public string? CPClassName { get; set; }
        public bool IsActive { get; set; }
    }
}
