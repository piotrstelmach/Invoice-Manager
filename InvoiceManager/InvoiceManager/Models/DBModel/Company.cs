using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quick_Invoice.Models
{
    public class Company
    {             
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Company name is required")]
        public string Company_Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public Address Address { get; set; }
        [Required(ErrorMessage = "NIP is required")]
        [StringLength(10)]
        public string NIP { get; set; }
        [Required(ErrorMessage = "KRS is required")]
        [StringLength(10)]
        public string KRS { get; set; }
        [Required(ErrorMessage = "Bank number is required")]
        public string Bank_Number { get; set; }
        public string Bank_swift { get; set; }


        public virtual Client Client { get; set; }

    }
}