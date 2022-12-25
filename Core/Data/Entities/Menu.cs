using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class Menu
    {
        public Menu()
        {
            Permission = new HashSet<Permission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ControlId { get; set; }
        public int? Pcid { get; set; }
        public string? ControlName { get; set; }
        public string? ControlType { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsAp { get; set; }
        public bool? IsMenu { get; set; } = false;
        public string? Route { get; set; }
        public string? Icon { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
    }
}
