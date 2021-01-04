using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
using BusinessLayerLibrary.ManagClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageFoodMenuController : BaseController
    {
        MngList objList = new MngList();
        MngInsert objInsert = new MngInsert();
        [HttpGet]
        public ActionResult ViewFoodMenu()
        {
            List<ClsMainModel.ClsPriceMenu> lst = objList.Admin_GetPriceMenu();
            TempData["Statusdetailserror"] = MngList.ExceptionMsg;
            return View(lst);
        }
        [HttpGet]
        public ActionResult AddFoodMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFoodMenu(ClsMainModel.ClsPriceMenu m, HttpPostedFileBase tmfiles)
        {
            if (m.PriceMenuTitle == "" && m.Price <= 0 && m.PriceMenuPicture == "")
            {
                TempData["Statusdetailserror"] = "Please Fill All Fields";
                return View(m);
            }

            if (tmfiles.FileName != null && tmfiles.ContentLength <= 0)
            {
                TempData["Statusdetailserror"] = "Please Select File";
                return View(m);
            }
            string fileType = MimeMapping.GetMimeMapping(tmfiles.FileName);

            #region ADO_Code
                bool Status = false;
                string StatusDetails = null;

                string sliderFolderPath = System.Configuration.ConfigurationManager.AppSettings["FoodMenuImagePATH"].ToString();  //FolderPath
                string FileName = tmfiles.FileName;  //FileName
                m.PriceMenuPicture = sliderFolderPath + FileName;
                m.PriceMenuPictureOnlyPath = sliderFolderPath;
                objInsert.Admin_InsertFoodMenu(m.PriceMenuTitle, m.Price,m.PriceMenuPicture, m.PriceMenuPictureOnlyPath, 1, out Status, out StatusDetails);
                if (Status)
                { TempData["Statusdetails"] = StatusDetails; return View(); }
                else
                { TempData["Statusdetailserror"] = StatusDetails; return View(m); }
            #endregion
        }

        [HttpGet]
        public ActionResult AddSubFoodMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubFoodMenu(FormCollection frmCollection)
        {
            return View();
        }
    }
}