using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class ListModel<T> where T : class
    {
        public object List { get; set; } = new List<string>();
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int ItemCount { get; set; }
    }
}
