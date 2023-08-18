using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class FaultGroupDTO
    {
        public int FaultGroupId { get; set; }
        public string? FaultGroup { get; set; }
        public string? FGroupCode { get; set; }
        public bool IsActive { get; set; }
    }
}
