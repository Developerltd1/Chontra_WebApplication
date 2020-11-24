using MyCode.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class LoginController :  BaseController
    {

        DALUsers dbObj = new DALUsers();
        // GET: Admin/Login
        public ActionResult Display()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(MyCode.DAL.ClsDALUsers model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
               // ShowMessage(MessageBox.Error, MessageTitle.Error, "User Name and Password Required");
                return View(model);
            }
            try
            {
                string _StatusDetails = null;
                bool _Status = false;
                System.Data.DataTable dt = dbObj.AuthenticateUser(model.Email, model.Password, out _Status, out _StatusDetails);
                if (_Status && dt.Rows.Count > 0)
                {
                    ClsDALUsers u = new ClsDALUsers();
                   
                    u.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    u.UserName = dt.Rows[0]["UserName"].ToString();
                    u.FullName = dt.Rows[0]["FullName"].ToString();
                    //u.OrganizationName = dt.Rows[0]["OrganizationName"].ToString();
                    //u.Organization_ID = Convert.ToInt32(dt.Rows[0]["Organization_ID"]);
                    u.Email = dt.Rows[0]["Email"].ToString();
                    u.Role_ID = Convert.ToInt32(dt.Rows[0]["Role_ID"]);


                   // Session["ProfileImage"] = dt.Rows[0]["LogoPath"].ToString();
                    Session["LoginUserModel"] = u;
                    Session["UserID"] = u.UserID;
                    //Session["Organization_ID"] = u.Organization_ID;
                    //Session["Organization"] = u.OrganizationName;
                    Session["UserFullName"] = u.FullName;
                    Session["UserUserName"] = u.UserName;
                    FormsAuthentication.SetAuthCookie(u.UserName, false);
                    return RedirectToAction("Dashboard", "Dashboard", "Admin");
                }
                else
                {
                    TempData["LoginFail"] = _StatusDetails;

                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception ex)
            {
                TempData["LoginFail"] = ex;
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Login", "Admin");
        }

    }
}