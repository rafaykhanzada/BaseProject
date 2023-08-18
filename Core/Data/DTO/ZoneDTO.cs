using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class ZoneDTO
    {
        public int ZoneOrStationId { get; set; }
        public string? ZoneOrStation { get; set; }
        public bool? IsStation { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }
    }
}
