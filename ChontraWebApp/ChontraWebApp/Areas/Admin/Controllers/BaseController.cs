using MyCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public int Campus_ID
        {
            get
            {
                return 1;
            }
            set
            {
                Campus_ID = 1;
            }
        }
        public int LoginRole_ID { get; set; }
        public int LoginUserID { get; set; }
        public string LoginUserName { get; set; }
        public string LoginFullName { get; set; }
        public bool CanAdd { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public string FormVisited { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object[] attributes = filterContext.ActionDescriptor.GetCustomAttributes(true);
            if (attributes.Any(a => a is AllowAnonymousAttribute)) return;

            HttpSessionStateBase session = filterContext.HttpContext.Session;
            ////If the browser session or authentication session has expired...
            MyCode.DAL.ClsDALUsers u = (MyCode.DAL.ClsDALUsers)Session["LoginUserModel"];

            #region Session Permissions
            if (session.IsNewSession || u == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();

                    // For AJAX requests, return result as a simple string, 
                    // and inform calling JavaScript code that a user should be redirected.

                    //JsonResult result = Json("SessionTimeout", "text/html");
                    //filterContext.Result = result;
                }
                else
                {
                    //For round-trip requests,
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "Login" }, { "Action", "Login" } });
                }

            }
            else
            {
                LoginUserID = u.UserID;
                LoginUserName = u.UserName;
                LoginFullName = u.FullName;
                LoginRole_ID = u.Role_ID;
            }
            #endregion

            #region Check Permissions
            if (!CheckCurrentPageAccess())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Login" }, { "Action", "Login" }, { "Area", "Admin" } });
            }
            #endregion


            base.OnActionExecuting(filterContext);
        }
        public class NotAuthorizeAttribute : FilterAttribute
        {
            // Does nothing, just used for decoration
        }

        private bool CheckCurrentPageAccess()
        {
            bool result = false;

            if (Request.RawUrl.ToString() == "/"
                || Request.RawUrl.ToString().Equals("Admin/Login/LogOff")
                || Request.RawUrl.ToString().Equals("/Login/ChangePassword")
               || Request.RawUrl.ToString().Equals("/Home/Dashboard"))
            {
                return true;
            }
            if (Request.IsAjaxRequest())
            {
                return true;
            }
            string[] arr = Request.RawUrl.Split('/');

            string NavUrl = "";
            if (arr.Count() == 4 || arr.Count() == 5)
            {
                string Url1 = arr[1], Url2 = arr[2], Url3 = "";
                if (arr[3].Contains('?'))
                {
                    arr = arr[3].Split('?');
                    Url3 = arr[0];
                }
                else
                {
                    Url3 = arr[3];
                }
                NavUrl = string.Format("/{0}/{1}/{2}", Url1, Url2, Url3);
            }
            else
            {
                string Url1 = arr[1], Url2 = "";
                if (arr[2].Contains('?'))
                {
                    arr = arr[2].Split('?');
                    Url2 = arr[0];
                }
                else
                {
                    Url2 = arr[2];
                }
                NavUrl = string.Format("/{0}/{1}", Url1, Url2);
            }

            if(Session["LoginUserModel"] != null) {
                return true;
            }
            List<MyCode.DAL.ClsWebPages> Menus = (List<MyCode.DAL.ClsWebPages>)Session["SideMenus"];
            if (Menus == null)
            {
                return false;
            }

            foreach (MyCode.DAL.ClsWebPages M in Menus)
            {
                foreach (string str in M.Urls)
                {
                    if (str == NavUrl)
                    {
                        CanAdd = M.HasInsert;
                        CanUpdate = M.HasUpdate;
                        CanDelete = M.HasDelete;
                        return true;
                    }
                }
            }

            return result;

        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            string actionName = requestContext.RouteData.Values["action"].ToString2();
            string controllerName = requestContext.RouteData.Values["controller"].ToString2();
            string methodType = requestContext.HttpContext.Request.HttpMethod.ToString2();
            string data = requestContext.HttpContext.Request.Form.ToString2();
            if (!string.IsNullOrEmpty(actionName.ToString2()) && actionName != "Menus" && actionName != "Dashboard")
            {
                if (actionName == "Login")
                {
                    //remove UserName and Password.
                    data = "";
                }
                if (Session["UETUser"] != null)
                {
                    //Utility.SaveLog(((MyCode.DAL.ClsDALUsers)Session["UETUser"]).UserID, controllerName, actionName, methodType, data);
                }
            }
        }




        #region ShowMessage
        public void ShowMessage(MessageBox MessageType, MessageTitle Title, string Message = "Record Saved Successfully")
        {
            TempData["Opertaion"] = Title;
            TempData["Message"] = Message;
            switch (MessageType)
            {
                case MessageBox.Success:
                    TempData["CssClass"] = "alert-success";
                    TempData["IconColor"] = "";
                    TempData["Bg"] = "bg-success";
                    TempData["TextColor"] = "text-white";
                    TempData["Border"] = " border-0";
                    TempData["IconClass"] = "mdi-check-bold";
                    TempData["Opertaion"] = "Success";
                    break;
                case MessageBox.Error:
                    TempData["CssClass"] = "alert-danger";
                    TempData["IconColor"] = "";
                    TempData["Bg"] = "bg-danger";
                    TempData["TextColor"] = "text-white";
                    TempData["Border"] = " border-0";
                    TempData["IconClass"] = "mdi-window-close";
                    TempData["Opertaion"] = "Error";
                    break;
                case MessageBox.Warning:
                    TempData["CssClass"] = "alert-warning";
                    TempData["IconColor"] = "";
                    TempData["Bg"] = "bg-warning";
                    TempData["TextColor"] = "text-white";
                    TempData["Border"] = " border-0";
                    TempData["IconClass"] = "mdi-hand-left";
                    TempData["Opertaion"] = "Warning";
                    break;
                case MessageBox.Info:
                    TempData["CssClass"] = "alert-info";
                    TempData["IconColor"] = "";
                    TempData["Bg"] = "bg-info";
                    TempData["TextColor"] = "text-white";
                    TempData["Border"] = " border-0";
                    TempData["IconClass"] = "mdi-information";
                    TempData["Opertaion"] = "Info";
                    break;
                default:
                    TempData["CssClass"] = "alert-info";
                    TempData["IconColor"] = "";
                    TempData["Bg"] = "bg-info";
                    TempData["TextColor"] = "text-white";
                    TempData["Border"] = " border-0";
                    TempData["IconClass"] = "mdi-information";
                    TempData["Opertaion"] = "";
                    break;
            }
        }
        #endregion

    }

    public enum MessageTitle
    {
        Information = 0,
        Saved = 1,
        Updated = 2,
        Error = 3,
        Warning = 4,
        Deleted = 5
    }
    public enum MessageBox
    {
        Success = 1,
        Error = 2,
        Warning = 3,
        Info = 4
    }
}