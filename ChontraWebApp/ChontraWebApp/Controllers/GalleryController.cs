using BusinessLayerLibrary.ManagClass;
using System.Web.Mvc;

namespace ChontraWebApp.Controllers
{
    public class GalleryController : Controller
    {
        [HttpGet]
        public ActionResult GalleryPage()
        {
            ViewBag.Title = "Gallery";
            MngList obj = new MngList();
            return View(obj.GetListofEvent());
        }

        [HttpGet]
        public ActionResult GalleryPictureDetail(int id)
        {
            ViewBag.Title = "Event Gallery";
            MngList obj = new MngList();
            return View(obj.GetListofEventGalleryByEventID(id));
        }
    }
}