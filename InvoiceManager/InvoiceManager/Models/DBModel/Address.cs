using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quick_Invoice.Models
{
    public class Address
    {
        [Key]
        public int id { get; set; }

        public string Street { get; set; }
        [Required(ErrorMessage = "House number is required")]
        public int House_Number { get; set; }
        public int Flat_Number { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Zip code is required")]
        [StringLength(6)]
        public string Zip_code { get; set; }

        public virtual Client Client { get; set; }

        public virtual Seller Seller { get; set; }
        public ICollection<Company> Company { get; set; }
    }
}