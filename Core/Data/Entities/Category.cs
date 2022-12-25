using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class Category:HasIdDate
    {
        public string? Name { get; set; }
    }
}
