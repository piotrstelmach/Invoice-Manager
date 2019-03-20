using System.ComponentModel.DataAnnotations;

namespace Quick_Invoice.Models
{
    public class PaymentType
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Payment type is required")]
        [StringLength(30)]
        public string Payment_Type { get; set; }


        public virtual Invoice Invoice{get;set;}
    }
}