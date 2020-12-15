using BusinessLayerLibrary;
using BusinessLayerLibrary.ManagClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BusinessLayerLibrary.CustomModels.ClsMainModel;
using static BusinessLayerLibrary.ViewModel.MainViewModels;
using static MyCode.Utilities.MyExtensions;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageEventOrderController : BaseController //Controller
    {
        MngList obj = new MngList();
        MngInsert objInsert = new MngInsert();
        MngEdit objEdit = new MngEdit();

       
        public JsonResult SendtoAddEventOrder(string ReciptNo, string CustomerName, string CustomerID)
        {

            TempData["tmpReciptNo"] = ReciptNo;
            TempData["tmpCustomerName"] = CustomerName;
            TempData["tmpCustomerID"] = CustomerID;
            return Json(new { redirect = "AddEventOrder"}, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult AddEventOrder()
        {
            ViewBag.TableHeaderName = "AddEventOrder";
            return PartialView("AddEventOrder");
          
        }


        [HttpPost]
        public ActionResult CustomerTotalEventInfo(int id)
        {
            DataTable dt = obj.Admin_GetCustomerInfoByReciptNo(id);
            List<EventTiming_N_Customer_N_ServicesPicture_N_EventType_N_ServicesViewModels> lst = new List<EventTiming_N_Customer_N_ServicesPicture_N_EventType_N_ServicesViewModels>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lst.Add(new EventTiming_N_Customer_N_ServicesPicture_N_EventType_N_ServicesViewModels()
                {
                    CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]),
                    EventType = Convert.ToString(dt.Rows[i]["EventType"]),
                    SubServiceTitle = Convert.ToString(dt.Rows[i]["SubServiceTitle"]),
                    PriceMenuTitle = Convert.ToString(dt.Rows[i]["PriceMenuTitle"]),
                    Price = Convert.ToInt32(dt.Rows[i]["Price"]),
                });
            }

            return View(lst);
        }

        // [HttpGet]
        // public ActionResult AddEventOrder()
        // {
        //     ViewBag.TableHeaderName = "AddEventOrder";
        //     return View();
        // }

        [HttpPost]
        public ActionResult AddEventOrder(FormCollection myformdata)
        {
            bool status = false;
            string statusDetail = null;
            try
            {
                ClsCustomerEventOrder m = new ClsCustomerEventOrder();
                m.Customer_ID = Convert.ToInt32(1);
                m.SubServices_ID = Convert.ToInt32(myformdata["SubServiceID"]);
                m.EventType_ID = Convert.ToInt32(myformdata["EventType_ID"]);
                m.EventTimingTypeID = Convert.ToInt32(myformdata["EventTimingTypeID"]);
                m.PriceMenu_ID = Convert.ToInt32(myformdata["PriceMenuID"]);
                m.CreatedByUser_ID = 1;



                objInsert.Admin_InsertCustomerEventOrder(m.Customer_ID,m.Services_ID,m.SubServices_ID,m.EventType_ID,m.PriceMenu_ID,m.CreatedByUser_ID,out status,out statusDetail);
                if(status)
                {
                    TempData["Statusdetails"] = "Record Save Successfully !";
                    return View("AddEventOrder");
                }
                else
                {
                    TempData["Statusdetailserror"] = "Error Occurred: " + statusDetail;
                }
                return View("AddEventOrder");
            }
            catch (Exception ex)
            {
                TempData["Statusdetailserror"] = "An exception occurred: " + ex.Message;
                return RedirectToAction("AddEventOrder");
            }
        }



        [HttpGet]
        public ActionResult ViewEventOrder()
        {
            ViewBag.TableHeaderName = "Customer Table";
            var lst = obj.Admin_GetAllCustomer();
            return View(lst);
        }








        //ComboCall

       [HttpGet]
        public JsonResult vComboPriceMenu(int PriceMenuID)
        {
            MngCombo cb = new MngCombo();
           var combolst = cb.GetPriceMenu();
          
             DataTable dt = cb.GetAllPriceMenu_ByPriceMenuID(PriceMenuID);
            string price = dt.Rows[0]["Price"].ToString();

            return Json(price, JsonRequestBehavior.AllowGet);
        }

        public ActionResult vComboPriceMenuAjax(int PriceMenuID)
        {
            MngCombo cb = new MngCombo();
            var combolst = cb.GetPriceMenu();

            combolst.Insert(0, new DropDownModal() { Text = "---Please Select---" });
            var data = combolst.Select(a => "<option value='" + (a.Value.ToString() == "0" ? "" : a.Value.ToString()) + "'>" + a.Text + "</option>");

            return Content(String.Join("", data));
        }

        [HttpGet]
        public JsonResult vComboGetEventTimingType()
        {
            MngCombo cb = new MngCombo();
            var combolst = cb.GetEventTimingType();
            return Json(combolst, JsonRequestBehavior.AllowGet);
        }
        

    }
}