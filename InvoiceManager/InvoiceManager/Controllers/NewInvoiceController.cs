using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    public class NewInvoiceController : Controller
    {
        // GET: NewInvoice
        public ActionResult Index()
        {
            return View();
        }
    }
}