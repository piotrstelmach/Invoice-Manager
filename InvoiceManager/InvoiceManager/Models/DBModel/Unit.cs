using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quick_Invoice.Models
{
    public class Unit
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Unit name is required")]
        public string Unit_Name { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}