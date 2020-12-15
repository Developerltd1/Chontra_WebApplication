using BusinessLayerLibrary.ManagClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MyCode.Utilities.MyExtensions;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ComboBoxController : Controller
    {
        [HttpGet]
        public JsonResult vComboPriceMenu()
        {
            MngCombo cb = new MngCombo();
            List<DropDownModal> lstPages = cb.GetSelectPage();
            return Json(lstPages, JsonRequestBehavior.AllowGet);
        }
    }
}