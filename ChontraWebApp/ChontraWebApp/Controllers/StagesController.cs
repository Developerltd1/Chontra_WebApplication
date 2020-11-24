using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Controllers
{
    public class StagesController : Controller
    {
        [HttpGet]
        public ActionResult StagesPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StagesDetails()
        {
            return View();
        }
    }
}