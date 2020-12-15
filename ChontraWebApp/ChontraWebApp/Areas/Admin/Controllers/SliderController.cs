using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class SliderController : BaseController //  Controller //
    {
        MngList objList = new MngList();
        MngInsert objInsert = new MngInsert();

        [HttpGet]
        public ActionResult ViewSlider()
        {
           DataTable abcdt = objList.Admin_DisplaySlider();
            return View(abcdt);
        }

        [HttpGet]
        public ActionResult AddSlider()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddSlider(ClsMainModel.ClsSlider m, HttpPostedFileBase tmfiles)
        {

            if (tmfiles.FileName != null && tmfiles.ContentLength <= 0)
            {
                TempData["Statusdetailserror"] = "Please Select File";
                return View(m);
            }
            string fileType = MimeMapping.GetMimeMapping(tmfiles.FileName);
            if(fileType == "video/mp4") //Video
            {
                m.isVideo = true;
                imgORvdo(m, tmfiles);
            }
            else  //Image
            {
                m.isVideo = false;
                imgORvdo(m, tmfiles);
            }
           
          return View(m);
        }

        public void imgORvdo(ClsMainModel.ClsSlider m, HttpPostedFileBase tmfiles)
        {
            int OutSliderID = 0;
            bool Status = false;
            string StatusDetails = null;
            objInsert.Admin_InsertSliderOnlyDetails(m.SliderTitle, m.SliderDecription, m.SelectPage, m.isVideo, 1, out Status, out StatusDetails, out OutSliderID);
            if (Status)
            {
                string sliderFolderPath = System.Configuration.ConfigurationManager.AppSettings["SliderImagePATH"].ToString();  //FolderPath
                string FileName = null;//for New FileName
                FileName = Path.GetFileNameWithoutExtension(tmfiles.FileName);  //Old FileName
                FileName = OutSliderID.ToString() + "_" + tmfiles.FileName;// + Path.GetExtension(tmfiles.FileName); //Replace [File Expression 1_abc.jpg]
                tmfiles.SaveAs(Path.Combine(Server.MapPath(sliderFolderPath), FileName)); //Save to ServerFolder
                objInsert.Admin_SliderUpdateByID(OutSliderID, sliderFolderPath + FileName, out Status, out StatusDetails);

                TempData["Statusdetails"] = StatusDetails;
            }
            else
            {
                TempData["Statusdetailserror"] = StatusDetails;
            }
        }
    }
}