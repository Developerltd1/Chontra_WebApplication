using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer2.CustomModels;

namespace BusinessLayer2
{
    public class MngHome
    {
        # region Homepage

        dbSiteEntities objContext;

        public List<tblText> GetChiefMessagesforIntro()
        {
            using (objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                return objContext.tblTexts.Take(2).ToList();

            }
        }
        public bcChiefMessage  GetChiefMessageforHome()
        {

            using (objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                //string obj = objContext.tblTexts.OrderByDescending(t => t.TextType_ID.Equals(1)).First().TextDetail;
                return objContext.tblTexts.Where(t=> t.TextType_ID==1).OrderByDescending(t=> t.TextID).Select(t => new bcChiefMessage { MessageTitle = t.TextTitle, MessageDetails = t.TextDetail, ImagePath = t.ImagePath }).First();
               // return obj.TextDetail;

            }
        }

        public bcChiefMessage GetChiefMessage2forHome()
        {

            using (objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                //string obj = objContext.tblTexts.OrderByDescending(t => t.TextType_ID.Equals(1)).First().TextDetail;
                return objContext.tblTexts.Where(t => t.TextType_ID == 2).OrderByDescending(t => t.TextID).Select(t => new bcChiefMessage { MessageTitle = t.TextTitle, MessageDetails = t.TextDetail, ImagePath = t.ImagePath }).First();
                // return obj.TextDetail;

            }
        }

        public bcAboutMessage GetAboutMessageforHome()  // 10 is type for About 
        {
            using (objContext = new dbSiteEntities())
            {                                
                return objContext.tblTexts.Where(t => t.TextType_ID == 10).OrderByDescending(t => t.TextID).Select(t => new bcAboutMessage { MessageTitle = t.TextTitle, MessageDetails = t.TextDetail }).First();
            }
        }

        public List<tblNew> GetNewsListforHome()
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblNews.Where(n=> n.IsActive.Equals(true)).Take(5).ToList();
            }
        }
     
        public List<tblEvent> GetEventListforHome()
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblEvents.Take(10).ToList();
            }
        }

        public List<tblEvent> GetEventListofType(int type)
        {
            string ty = "";
            if (type == 1)
                ty = "National";
            else if (type == 2)
                ty = "Local";
            else if (type == 3)
                ty = "International";
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblEvents.Where(t=> t.EventType.Equals(ty)).Take(5).ToList();
            }
        }
        public List<tblSlider> GetSliderImagesforHome()
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblSliders.ToList();
            }
        }

        public List<tblGallery> GetGalleryforHome()
        {
            using(objContext = new dbSiteEntities())
            {
                return objContext.tblGalleries.Where(g=> g.IsActive.Equals(true)).OrderByDescending(s => s.GalleryID).Take(10).ToList();
            }
        }

        public List<tblTestimonial> GetTestimonialforHome()
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblTestimonials.OrderByDescending(s => s.TestimonialID).ToList();
            }
        }

        public List<tblFact> GetFactsforHome()
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblFacts.ToList();
            }
        }
        public List<tblContact> GetAddressesForFooter()
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblContacts.Where(c=> c.IsActive.Equals(true)).Take(4).ToList();
            }
        }

        public List<tblTeamMember> GetTeamforHome()
        {
            using (dbSiteEntities objContext = new dbSiteEntities())
            {
                return objContext.tblTeamMembers.Where(t=> t.IsActive.Equals(true)).Take(12).ToList();
                 //   objContext.usp_GetCabinetMembers().Select(b => new bcCabinet { CabinetID = b.SocMemID, CabinetName = b.MemberName, DesignationName = b.DesinationTitle, Qualification = b.JobDetails, ImagePath = b.ImagePath, Email = b.MemberEmail }).ToList();
                //return objContext.tblTeamMembers.Where()
            }
        }

        public List<tblClient> GetClientforHome()
        {
            using (dbSiteEntities objContext = new dbSiteEntities())
            {
                return objContext.tblClients.Where(t => t.IsActive.Value.Equals(true)).Take(8).ToList();
                //   objContext.usp_GetCabinetMembers().Select(b => new bcCabinet { CabinetID = b.SocMemID, CabinetName = b.MemberName, DesignationName = b.DesinationTitle, Qualification = b.JobDetails, ImagePath = b.ImagePath, Email = b.MemberEmail }).ToList();
                //return objContext.tblTeamMembers.Where()
            }
        }

        public List<tblDownload> GetDownloadsforHome()
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblDownloads.Where(c => c.IsActive.Equals(true)).OrderByDescending(o => o.DownloadID).Take(10).ToList();
            }
        }

        //public List<bcCabinet> GetExecutiveMembersforHome() 
        //{
        //    using (dbSiteEntities objContext = new dbSiteEntities())
        //    {
        //        return objContext.usp_GetExecutiveMembers().Select(b => new bcCabinet { CabinetID = b.SocMemID, CabinetName = b.MemberName, ImagePath = b.ImagePath }).ToList();               
        //    }
        //}



        public bcTax GetTaxServiceforHome()
        {
            using (objContext = new dbSiteEntities())
            {
                tblService o = new tblService();
                return objContext.tblServices.Where(s => s.ServiceName.Equals("Taxes We Pay")).Select(s => new bcTax { Title = s.ServiceName, B1 = s.B1, B2 = s.B2, B3 = s.B3, B4 = s.B4 }).First();
                //return o;
            }
        }
       

       
     
        #endregion

      



    }
}
