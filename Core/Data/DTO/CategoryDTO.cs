﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
