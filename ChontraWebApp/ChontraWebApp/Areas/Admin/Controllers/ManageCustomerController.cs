using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
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
        MngInsert objInsert = new MngInsert();

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

        [HttpPost]
        public ActionResult AddCustomerPartial(ClsMainModel.ClsCustomer mdl)
        {
            try
            {
              int id =  objInsert.Admin_InsertAllCustomer(mdl);
              if (id > 0)
              {
                    return View("ViewCustomer", obj.Admin_GetAllCustomer());
              }
              else
              {
                    return PartialView("AddCustomerPartial");
                    //return Json(new { IsSuccess = false, message = "Record is Not Saved !" }, JsonRequestBehavior.AllowGet);
              }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult EditCustomerPartial()
        {
            try
            {
              //  int id = objInsert.Admin_InsertAllCustomer(id);
                return PartialView("AddCustomerPartial");
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}