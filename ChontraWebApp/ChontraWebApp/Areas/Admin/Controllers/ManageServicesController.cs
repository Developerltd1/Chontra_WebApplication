using BusinessLayerLibrary.ManagClass;
using System.Data;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageServicesController : BaseController //Controller
    {

        MngList objList = new MngList();
        public ActionResult ViewServices()
        {
            DataTable abcdt = objList.Admin_DisplaySlider();
            return View(abcdt);
        }

        [HttpGet]
        public ActionResult AddNewServices()
        {
            return View();
        }



        [HttpGet]
        public ActionResult ViewSubServices()
        {
            ViewBag.TableHeaderName = "Stages List";
            return View();
        }
    }
}