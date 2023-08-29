using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class Logger:HasId
    {
        public string? LogType { get; set; }
        public string? InFunction { get; set; }
        public string? OnTask { get; set; }
        public string? ObjectData { get; set; }
        public DateTime DateTime { get; set; }
        public string? UserId { get; set; }
    }
}
