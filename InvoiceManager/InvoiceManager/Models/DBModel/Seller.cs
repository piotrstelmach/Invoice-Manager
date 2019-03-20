using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quick_Invoice.Models
{
    public class Seller
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string First_name { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string Last_name { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public virtual Address Address { get; set; }
        [Required(ErrorMessage = "NIP is required")]
        [StringLength(10)]
        public string NIP { get; set; }
        public virtual Company Company { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}