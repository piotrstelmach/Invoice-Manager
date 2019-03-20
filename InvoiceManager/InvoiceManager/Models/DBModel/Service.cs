using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quick_Invoice.Models
{
    public class Service
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Service name is required")]
        [StringLength(160)]
        public string Service_name { get; set; }
        [Required(ErrorMessage = "Price netto is required")]
        public double Price_netto { get; set; }
        [Required(ErrorMessage = "Price brutto is required")]
        public double Price_brutto { get; set; }
        [Required(ErrorMessage = "VAT is required")]
        public double VAT { get; set; }

        public ICollection<Invoice> Invoice { get; set; }
    }
}