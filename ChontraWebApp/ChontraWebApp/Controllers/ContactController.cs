using BusinessLayerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChontraWebApp.Controllers
{
    public class ContactController : Controller
    {
        MngList obj = new MngList();
        [HttpGet]
        public ActionResult ContactPage()
        {
            ViewBag.Title = "Contact Page";
            BusinessLayerLibrary.CustomModels.ClsMainModel.ClsBranch  mBranch = obj.GetListofBranch(1);  //Chontra
            //BusinessLayerLibrary.CustomModels.ClsMainModel.ClsContact mContact = obj.GetListofContact();
            //BusinessLayerLibrary.ViewModel.MainViewModels.Branch_N_ContactPageViewModels vm = new BusinessLayerLibrary.ViewModel.MainViewModels.Branch_N_ContactPageViewModels();

            //vm.ContactID = mContact.ContactID;
            //vm.ContactName = mContact.ContactName;
            //vm.ContactMessage = mContact.ContactMessage;
            //vm.ContactDescription = mContact.ContactDescription;
            //vm.ContactEmail = mContact.ContactEmail;
            //vm.ContactAddress = mContact.ContactAddress;
            //vm.ContactPhone = mContact.ContactPhone;
            //vm.ContactMobile1 = mContact.ContactMobile1;
            //vm.ContactMobile2 = mContact.ContactMobile2;

            return View(mBranch);
        }
    }
}