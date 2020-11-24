using MyCode.DAL;
using MyCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageRolesController : BaseController
    {
        DALRoles obj = new DALRoles();
        MyCode.DAL.DALRoles mObj = new MyCode.DAL.DALRoles();
        // GET: Admin/Roles
        public ActionResult ViewRoles(ClsDALRoles model)
        {
            ViewBag.CanAdd = CanAdd = true;  //StaticChange
            ViewBag.CanUpdate = CanUpdate = true;  //StaticChange
            ViewBag.CanDelete = CanDelete = true;  //StaticChange

            try
            {
                var data = obj.GetAllRoles(model);
                return View(data);
            }
            catch (Exception ex)
            {
                BaseController BsObj = new BaseController();
                BsObj.ShowMessage(MessageBox.Error, MessageTitle.Error, ex.Message);
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditRole(string id) 
        {
            try
            {
                var data = obj.GetRoleByID(Utilities.MyExtensions.DecryptURL(id).ToInt32());
                return View(data);
            }
            catch (Exception ex)
            {
                BaseController bObj = new BaseController();
                bObj.ShowMessage(MessageBox.Error, MessageTitle.Error, ex.Message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditRole(ClsDALRoles model)
        {
            try
            {
                if (!CanUpdate)
                {
                    ShowMessage(MessageBox.Error, MessageTitle.Error, "You do not have Updation Permissions");
                    return View(model);
                }
                if (string.IsNullOrEmpty(model.RoleName))
                {
                    ShowMessage(MessageBox.Error, MessageTitle.Error, "Role Name Required");
                    return RedirectToAction("EditRole", "ManageRoles", new { id = Utilities.MyExtensions.EncryptURL(model.RoleID.ToString()) });
                }
                if (model.RoleWebPages.Count == 0)
                {
                    ShowMessage(MessageBox.Error, MessageTitle.Error, "Atleast one Page is Required for Role");
                    return RedirectToAction("EditRole", "ManageRoles", new { id = Utilities.MyExtensions.EncryptURL(model.RoleID.ToString()) });
                }
                 model.CreatedBy = LoginUserID;
                if (mObj.SaveRole(model))
                {
                    ShowMessage(MessageBox.Success, MessageTitle.Saved, "Role updated Successfully");
                    return RedirectToAction("ViewRoles", "ManageRoles","Admin");
                }
                else
                {
                    ShowMessage(MessageBox.Error, MessageTitle.Error, "Failed to add update Role");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageBox.Error, MessageTitle.Error, ex.Message);
            }
            return RedirectToAction("EditRole", new { id = Utilities.MyExtensions.EncryptURL(model.RoleID.ToString()) });

        }
    }
}