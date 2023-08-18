using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class CPClassDTO
    {
        public int CheckpointClassId { get; set; }
        public string? Class { get; set; }
        public string? CPClassCode { get; set; }
        public bool IsActive { get; set; }
    }
}
