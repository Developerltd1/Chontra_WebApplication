using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Controllers
{
    public class HomeController : Controller
    {
        MngList obj = new MngList();

        // GET: Home
        public ActionResult Home()
        {
            return View();
        }



        // PartialViews
        [ChildActionOnly]
        public PartialViewResult PartialAboutSlider()
        {
            return PartialView("_PartialHomeSlider", obj.GetListofSliderHome());
        }

        // PartialViews
        [ChildActionOnly]
        public PartialViewResult PartialDailyEventsTable()
        {
            return PartialView("_PartialCalander", obj.GetListofEventTiming());
        }

        // PartialViews
        [ChildActionOnly]
        public PartialViewResult PartialPriceMenu()
        {
            ViewBag.Title = "Price List Menu";
            MngList obj = new MngList();

            BusinessLayerLibrary.ViewModel.MainViewModels vm = new BusinessLayerLibrary.ViewModel.MainViewModels();
            vm.vmListClsPriceMenu = obj.GetListofPriceMenuDistinct();
            vm.vmListClsSubMenu = obj.GetListofSubMenu();
            return PartialView("_PartialMenu", vm);
        }


        // PartialViews
        [ChildActionOnly]
        public PartialViewResult PartialGallery()
        {
            ViewBag.Title = "Service Pictures";
            List <ClsMainModel.ClsServicesPicture> lst = obj.GetListofDistinctServicesPictures();
            return PartialView("_PartialGallery", lst);
        }

        // PartialViews
        [ChildActionOnly]
        public PartialViewResult PartiaServices()
        {
            ViewBag.Title = "Services";
            var lst = obj.GetListofServices();
            return PartialView("_PartiaServices", lst);
        }


       
    }
}