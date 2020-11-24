 using MyCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult Menus()
        {
            List<MyCode.DAL.ClsWebPages> Menus = new List<MyCode.DAL.ClsWebPages>();
            try
            {
               if (Session["SideMenus"] == null)
               {
                   Menus = AuthManageClass.GetSideMenusByRoleID();  // (1);_LoginRole_ID);
                   Session["SideMenus"] = Menus;
               }
               else
               {
                    Menus = (List<MyCode.DAL.ClsWebPages>)Session["SideMenus"];
                }
            }
            catch (Exception ex)
            {
               ShowMessage(MessageBox.Error, MessageTitle.Error, ex.Message);
            }
            return PartialView("_sidebar", Menus);
        }

    }
}