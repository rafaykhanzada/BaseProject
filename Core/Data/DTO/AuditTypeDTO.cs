﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class AuditTypeDTO
    {
        public int? Id { get; set; }
        public string? AudTypeCode { get; set; }
        public string? AudTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
