using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.DTOs
{
   public class EmailSetupVM
        {
            public int? Id { get; set; }
            [Required]
            public string Host { get; set; } = null!;
            [Required]
            public string Email { get; set; } = null!;
            [Required]
            public string Password { get; set; } = null!;
            [Required]
            public int Port { get; set; }
            public string? MobileNo { get; set; }
            public string? MobileNumberPassword { get; set; }
            public bool IsActive { get; set; }
    }
}
