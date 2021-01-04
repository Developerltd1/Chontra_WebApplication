using BusinessLayerLibrary.ManagClass;
using System.Web.Mvc;

namespace ChontraWebApp.Controllers
{
    public class MenusController : Controller
    {
        public ActionResult MenuPage()
        {
            ViewBag.Title = "Price List Menu";
            MngList obj = new MngList();

            BusinessLayerLibrary.ViewModel.MainViewModels vm = new BusinessLayerLibrary.ViewModel.MainViewModels();
            vm.vmListClsPriceMenu = obj.GetListofPriceMenuDistinct();
            vm.vmListClsSubMenu = obj.GetListofSubMenu();
            return View(vm);
        }

        [HttpGet]
        public ActionResult PriceMenuPage()
        {
            ViewBag.Title = "Price List Menu";
            MngList obj = new MngList();
          // return View(obj.GetListofPriceMenu());
            return View();
        }

       // [HttpGet]
       // public ActionResult PriceMenuPagePicture()
       // {
       //    // ViewBag.Title = "Price List Menu";
       //    // MngList obj = new MngList();
       //    // return View(obj.GetListofPriceMenu());
       // }


    }
}