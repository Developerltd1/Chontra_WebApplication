using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageCustomerController : Controller
    {
        [HttpGet]
        public ActionResult ViewCustomer()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddCustomerPartial()
        {
            return PartialView();
        }
    }
}