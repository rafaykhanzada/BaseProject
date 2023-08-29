using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class LoggerDTO
    {
        public string? LogType { get; set; }
        public string? InFunction { get; set; }
        public string? OnTask { get; set; }
        public string? ObjectData { get; set; }
        //  public DateTime? DateTime { get; set; }
        public string UserId { get; set; }
    }
}
