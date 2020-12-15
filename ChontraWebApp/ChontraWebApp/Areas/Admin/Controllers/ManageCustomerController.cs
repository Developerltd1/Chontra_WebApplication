using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
using BusinessLayerLibrary.ManagClass;
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
        MngEdit objEdit = new MngEdit();

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
              }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }





        [HttpGet]
        public ActionResult EditCustomerPartial(int id)
        {
              ClsMainModel.ClsCustomer mdl = objEdit.UpdateCustomer(id);
                  return PartialView(mdl);
             
           
        }
     //   [HttpPost]
     //   public ActionResult EditCustomerPartial(int id)
     //   {
     //
     //       try
     //       {
     //           ClsMainModel.ClsCustomer mdl = objEdit.UpdateCustomer(id);
     //           if (mdl.CustomerID > 0)
     //           {
     //               return PartialView(mdl);
     //           }
     //           else
     //           {
     //               TempData["Statusdetailserror"] = "Record not Deleted";
     //               return View("ViewCustomer", obj.Admin_GetAllCustomer());
     //           }
     //       }
     //       catch (Exception ex)
     //       {
     //           TempData["Statusdetailserror"] = ex.Message;
     //           throw;
     //       }
     //   }





        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                int confum = objEdit.DeleteCustomer(id);
                if (confum > 0)
                {
                    return View("ViewCustomer", obj.Admin_GetAllCustomer());
                }
                else
                {
                    TempData["Statusdetailserror"] = "Record not Deleted";
                    return View("ViewCustomer", obj.Admin_GetAllCustomer());
                }
            }
            catch (Exception ex)
            {
                TempData["Statusdetailserror"] = ex.Message;
                throw;
            }
        }

    }
}