using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object Data { get; set; } = new object();
    }
}
