using BusinessLayerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Controllers
{
    public class AboutController : Controller
    {
        MngList obj = new MngList();
        public ActionResult AboutPage()
        {
            return View();
        }

        // PartialViews
        [ChildActionOnly]
        public PartialViewResult PartialAboutSlider()
        {
            return PartialView("_AboutSlider", obj.GetListofSliderAboutPage());
        }
        [ChildActionOnly]
        public PartialViewResult PartialAboutTeam()
        {
            return PartialView("_AboutTeam", obj.GetListofUsers());
        }
    }
}