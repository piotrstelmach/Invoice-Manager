using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    public class DoneInvoicesController : Controller
    {
        // GET: DoneInvoices
        public ActionResult Index()
        {
            return View();
        }
    }
}