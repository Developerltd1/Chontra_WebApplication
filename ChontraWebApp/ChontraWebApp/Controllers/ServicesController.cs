using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
using BusinessLayerLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Controllers
{
    public class ServicesController : Controller
    {
        [HttpGet]
        public ActionResult ServicesPage()
        {
            ViewBag.Title = "Services";
            MngList obj = new MngList();
            return View(obj.GetListofServices());
        }

        [HttpGet]
        public ActionResult ServicesPicturesPage(int id)
        {
            ViewBag.Title = "Services Details";

            MngList obj = new MngList();
            MainViewModels vm = new MainViewModels();
            vm.vmListPicture_N_EventTypeViewModels = obj.GetListofServicesPicture(id);
            vm.vmListClsEventType = obj.EventTypeDistinct(id);

            return View(vm);
        }
    }
}