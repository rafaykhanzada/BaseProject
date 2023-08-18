using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class CPDeviationDTO
    {
        public int CheckpointDeviationId { get; set; }
        public string? Deviation { get; set; }
        public string? CPDevCode { get; set; }
        public bool IsActive { get; set; }
    }
}
