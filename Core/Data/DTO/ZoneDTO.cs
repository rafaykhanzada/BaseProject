using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class ZoneDTO
    {
        public int Id { get; set; }
        public string? ZoneCode { get; set; }
        public string? ZoneName { get; set; }
        public bool? IsStation { get; set; }
        public bool IsActive { get; set; }
    }
}
