using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class Config
    {
        public static string env { get; set; }
        public static IConfiguration config { get; set; }
    }
}
