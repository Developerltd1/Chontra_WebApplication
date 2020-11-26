using BusinessLayerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageCustomerController :BaseController //Controller
    {
        MngList obj = new MngList();
         
        [HttpGet]
        public ActionResult ViewCustomer()
        {
            ViewBag.TableHeaderName = "Customer Table";
            var lst = obj.Admin_GetAllCustomer();
            return View(lst);
        }


        [HttpGet]
        public ActionResult AddCustomerPartial()
        {
            return PartialView();
        }
    }
}