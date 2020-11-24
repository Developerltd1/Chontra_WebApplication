using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: Admin/ManageUser
        public ActionResult ViewUser()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }
    }
}