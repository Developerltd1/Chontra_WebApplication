using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
          
            //   "Admin/{controller}/{action}/{id}",
            context.MapRoute(
               "Admin_default",
               "Admin/{controller}/{action}/{id}",
               new { action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "ChontraWebApp.Areas.Admin.Controllers" }
           );
        }
    }
}