using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTOs
{
    public class MenuVM
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; } = "collapse";
        public object children { get; set; }
    }
    public class MenuLookUpVM
    {
        public int key { get; set; }
        public string label { get; set; }
        public string data { get; set; }
        public string type { get; set; }
        public object items { get; set; }
    }
}
