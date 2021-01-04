using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin
{
    public class ManageServicesController : Controller
    {
        // GET: Admin/ManageServices
        public  ActionResult Index()
        {
          
            return View();
        }

        public static async Task ABC()
        {
            await Task.Run(() => Console.WriteLine("ABCD"));
        }
    }
}