using InvoiceManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quick_Invoice.Models
{
    public class Invoice
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Invoice number is required")]
        public string Invoice_number { get; set; }
        [Required(ErrorMessage = "Client is required")]
        public virtual Client Client { get; set; }
        [Required(ErrorMessage = "Seller is required")]
        public virtual Seller Seller { get; set; }
        [Required(ErrorMessage = "User is required")]
        public Service Service { get; set; }
        public Product Product { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public virtual Unit Unit { get; set; }
        [Required(ErrorMessage = "Total price is required")]
        public double Total_price { get; set; }
        [Required(ErrorMessage = "Create date is required")]
        public DateTime Create_date { get; set; }
        [Required(ErrorMessage = "Payment deadline is required")]
        public DateTime PaymentDeadline { get; set; }
        [Required(ErrorMessage = "Payment type is required")]
        public virtual PaymentType PaymentType { get; set; }
        [Required(ErrorMessage = "Time left to pay is required")]
        public double LeftToPay { get; set; }
        public string Remarks { get; set; }

        public virtual ApplicationUser User { get; set; }


    }
}