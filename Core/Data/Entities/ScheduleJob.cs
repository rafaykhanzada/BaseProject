using Core.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class ScheduleJob:HasIdDate
    {
        public string? JobType { get; set; }
        public string? JobName { get; set; }
        public string? CronExpression { get; set; }
        public bool Enabled { get; set; }
        public DateTime? LastStart { get; set; }
        public DateTime? LastEnd { get; set; }
    }
}
