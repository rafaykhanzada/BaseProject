using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Core.Data.Entities
{
    public class CPDeviation : HasIdDate
    {
        public string? CPDevCode { get; set; }
        public string? CPDevName { get; set; }
    }
}
