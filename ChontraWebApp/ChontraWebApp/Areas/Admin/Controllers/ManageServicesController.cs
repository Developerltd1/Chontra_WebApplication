using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
using BusinessLayerLibrary.ManagClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;
using static BusinessLayerLibrary.ManagClass.MngCombo;
using static BusinessLayerLibrary.ViewModel.MainViewModels;

namespace ChontraWebApp.Areas.Admin.Controllers
{
    public class ManageServicesController : BaseController //Controller
    {

        MngList objList = new MngList();
        MngInsert objInsert = new MngInsert();
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

        [HttpGet]
        public ActionResult AddSubServices(int id)//(ClsMainModel.ClsServices m)
        {
            SubService_N_Services_N_ServicesPicture_N_EventType_ViewModels mm = new SubService_N_Services_N_ServicesPicture_N_EventType_ViewModels();
            mm.Services_ID = id;// m.ServicesID;
            ViewBag.ServicesID = mm.Services_ID;
            ViewBag.TableHeaderName = "Add Sub Services";

            #region ENUMS
            var lstEnum = new List<ConvertEnum>();
            foreach (StagesEventType lang in Enum.GetValues(typeof(StagesEventType)))
                lstEnum.Add(new ConvertEnum
                {
                    Value = (int)lang,
                    Text = lang.ToString()
                });
            ViewBag.MySkillEnum = lstEnum;
            #endregion

            return View(mm);
        }

        [HttpPost]
        public ActionResult AddSubServices(FormCollection formCollection, IEnumerable<HttpPostedFileBase> tmfiles)
        {
            bool status = false;
            string statusDetail = null;
            int SubServiceID = 0;
            List<string> msg = new List<string>();
            SubService_N_Services_N_ServicesPicture_N_EventType_ViewModels m = new SubService_N_Services_N_ServicesPicture_N_EventType_ViewModels();

            try
            {
              m.SubServiceTitle = formCollection["MySkills"];
              m.ServicesPictureDescription = formCollection["ServicesPictureDescription"];
              
              foreach (var item in tmfiles)
              {
                  m.ServicesPicturePath = Path.GetFileNameWithoutExtension(item.FileName);  //FileName
                  objInsert.usp_InsertSubServices(m.Services_ID, m.SubServiceTitle, m.ServicesPictureTitle, m.ServicesPictureDescription,
                                             "",m.isMain, LoginUserID, out SubServiceID, out status, out statusDetail);
                  if (status)
                  {
                    if(SubServiceID == objList.CheckPictureIdValid(SubServiceID)) 
                      { 
                        string StagePath = System.Configuration.ConfigurationManager.AppSettings["SubServiceStagesPATH"].ToString();
                        item.SaveAs(Path.Combine(Server.MapPath(StagePath), m.ServicesPicturePath)); //Save to ServerFolder
                        m.ServicesPicturePath =  StagePath + SubServiceID.ToString() + "_" + item.FileName; //Replace FileName
                      }
                  }
                  else
                  {
                      msg.Add("Title: " + m.ServicesPicturePath + "| Error: " + statusDetail + ".\n");
                      continue;
                  }
              }
              TempData["Statusdetailserror"] = msg;
            }
            catch (Exception ex)
            {
                TempData["Statusdetailserror"] = ex.Message;
            }
           
            ViewBag.TableHeaderName = "Add Sub Services";
            return View();
        }
    }
}