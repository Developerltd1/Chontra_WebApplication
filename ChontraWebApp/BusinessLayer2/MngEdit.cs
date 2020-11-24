using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer2.CustomModels;
using System.Globalization;

namespace BusinessLayer2
{
    public class MngEdit
    {
        dbSiteEntities objContext;

        # region Society


        public int EditChiefMessage(bcChiefMessage pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                obj = objContext.tblTexts.First(t => t.TextID.Equals(pobj.MessageID));
                obj.TextTitle = pobj.MessageTitle;
                obj.TextDetail = pobj.MessageDetails;
                //obj.TextPage = "Home";
                //obj.TextType_ID = pobj.TextType;
                obj.ModifyDate = DateTime.Now;
                obj.ModifyBy_ID = pobj.uid;
                obj.IsActive = pobj.MessageActive;   // whatever is passed will be saved here                
                return objContext.SaveChanges();
            }

        }

        public int EditChiefImage(bcChiefMessage pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                obj = objContext.tblTexts.First(t => t.TextID.Equals(pobj.MessageID));
                obj.ImagePath = pobj.ImagePath;
                obj.ModifyDate = DateTime.Now;
                obj.ModifyBy_ID = pobj.uid;
                return objContext.SaveChanges();
            }

        }

        public int EditMemberInfo(bcCabinet pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTeamMember obj = new tblTeamMember();
                obj = objContext.tblTeamMembers.First(t => t.MemID.Equals(pobj.CabinetID));
                obj.MemberName = pobj.CabinetName;
                obj.Qualification = pobj.Qualification;
                obj.Designation = pobj.DesignationName;
                //obj.EducationDetails = pobj.EduDetails;
                //obj.JobDetails = pobj.JobDetails;

                obj.MemberAddress = pobj.Address;
                obj.MemberEmail = pobj.Email;
                obj.MemberContactNo = pobj.Contactno;
                obj.IsActive = pobj.IsActive;
                obj.ModifyBy_ID = pobj.uid;
                obj.ModifyDate = DateTime.Now;

                return objContext.SaveChanges();
            }
        }

        public int EditMemberPicture(bcCabinet pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTeamMember obj = new tblTeamMember();
                obj = objContext.tblTeamMembers.First(t => t.MemID.Equals(pobj.CabinetID));
                obj.ImagePath = pobj.ImagePath;
                obj.ModifyBy_ID = pobj.uid;
                obj.ModifyDate = DateTime.Now;
                return objContext.SaveChanges();
            }
        }

      

        public int EditAboutMessage(bcAboutMessage pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                obj = objContext.tblTexts.First(t => t.TextID.Equals(pobj.MessageID));
                obj.TextTitle = pobj.MessageTitle;
                obj.TextDetail = pobj.MessageDetails;
                obj.ModifyDate = DateTime.Now;
                obj.ModifyBy_ID = pobj.uid;
                obj.IsActive = pobj.MessageActive;   // whatever is passed will be saved here                
                return objContext.SaveChanges();
            }

        }

        //Slider Edit
        public int EditSliderDetails(bcSlider paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblSlider entityModel = new tblSlider();
                entityModel = objContext.tblSliders.First(t => t.SliderID.Equals(paraModel.SliderID));
                entityModel.SliderCap1 = paraModel.Cap1;
                entityModel.IsActive = paraModel.IsActive;
                return objContext.SaveChanges();
            }
        }
        public int EditSliderImage(bcSlider paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblSlider entityObj = new tblSlider();
                entityObj = objContext.tblSliders.First(t => t.SliderID.Equals(paraModel.SliderID));
                entityObj.SliderImage = paraModel.ImagePath;
                return objContext.SaveChanges();
            }
        }

        public int EditTestiDetails(bcTestimonial paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTestimonial em = new tblTestimonial();
                em = objContext.tblTestimonials.First(t => t.TestimonialID.Equals(paraModel.TestiID));
                em.Name = paraModel.Name;
                em.Details = paraModel.Detail;
                em.IsActive = paraModel.IsActive;
               
                return objContext.SaveChanges();
            }
        }
        public int EditTestiImage(bcTestimonial paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTestimonial em = new tblTestimonial();
                em = objContext.tblTestimonials.First(t => t.TestimonialID.Equals(paraModel.TestiID));
                em.PicPath = paraModel.ImagePath;
                return objContext.SaveChanges();
            }
        }

        public int EnableTestiONPage(int id)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTestimonial em = new tblTestimonial();
                em = objContext.tblTestimonials.First(t => t.TestimonialID.Equals(id));
                em.IsActive = true;

                return objContext.SaveChanges();
            }
        }
        public int EditGalleryDetails(bcGallery paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblGallery em = new tblGallery();
                em = objContext.tblGalleries.First(t => t.GalleryID.Equals(paraModel.GalleryID));
                em.GalleryTitle = paraModel.Title;
                em.GalleryDescription = paraModel.Detail;
                em.IsActive = paraModel.IsActive;

                return objContext.SaveChanges();
            }
        }
        public int EditGalleryImage(bcGallery paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblGallery em = new tblGallery();
                em = objContext.tblGalleries.First(t => t.GalleryID.Equals(paraModel.GalleryID));
                em.GalleryImage = paraModel.ImagePath;
                return objContext.SaveChanges();
            }
        }

        public int EditQuoteDetails(bcQuote paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblQuote em = new tblQuote();
                em = objContext.tblQuotes.First(t => t.QuoteID.Equals(paraModel.Quoteid));
                em.isActive = paraModel.isActive;

                return objContext.SaveChanges();
            }
        }

        public int RecieveQuoteDetails(int id, int s)
        {
            using (objContext = new dbSiteEntities())
            {
                tblQuote em = new tblQuote();
                em = objContext.tblQuotes.First(t => t.QuoteID.Equals(id));
                em.IsRecieved = s;  // 1 means Recieved, 2 means Discard

                return objContext.SaveChanges();
            }
        }

        public int EditJobDetails(bcJob paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblJob em = new tblJob();
                em = objContext.tblJobs.First(t => t.JobID.Equals(paraModel.JobID));
                em.JobTitle = paraModel.JobTitle;
                em.PostDate = DateTime.ParseExact(paraModel.SPostDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                em.ClosingDate = DateTime.ParseExact(paraModel.SCloseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                em.Details = paraModel.Details;
                em.ModifyDate = DateTime.Now;
                em.ModifyByUser_ID = paraModel.MoifyByUser_ID;
                em.IsActive = paraModel.IsActive;

                return objContext.SaveChanges();

            }

        }

        public int EditJobAdvImage(bcJob paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblJob em = new tblJob();
                em = objContext.tblJobs.First(t => t.JobID.Equals(paraModel.JobID));
                em.AdvPath = paraModel.ImagePath;
                return objContext.SaveChanges();
            }

        }

        public int DeActiveJob(bcJob paraModel)
        {
            using (objContext = new dbSiteEntities())
            {
                tblJob em = new tblJob();
                em = objContext.tblJobs.First(t => t.JobID.Equals(paraModel.JobID));
                em.IsActive = false;
                em.ModifyDate = DateTime.Now;
                em.ModifyByUser_ID = paraModel.MoifyByUser_ID;
                return objContext.SaveChanges();
            }

        }

        public int EditClientInfo(bcClient pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblClient obj = new tblClient();
                obj = objContext.tblClients.First(t => t.ClientID.Equals(pobj.ClientID));
                obj.ClientName = pobj.ClientName;
                obj.IsActive = pobj.IsActive;
                return objContext.SaveChanges();
            }
        }

        public int EditClientPicture(bcClient pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblClient obj = new tblClient();
                obj = objContext.tblClients.First(t => t.ClientID.Equals(pobj.ClientID));
                obj.ClientLogo = pobj.ImagePath;
                return objContext.SaveChanges();
            }
        }

        public int EditNewsDetails(bcNews pobj) 
        {
            using (objContext = new dbSiteEntities())
            {
                tblNew obj = new tblNew();
                obj = objContext.tblNews.First(t => t.NewsID.Equals(pobj.NewsID));
                obj.NewsDescription = pobj.NewsDetails;
                obj.IsActive = pobj.IsActive;
                return objContext.SaveChanges();
            }
        }

        public int EditNewsPicture(bcNews pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblNew obj = new tblNew();
                obj = objContext.tblNews.First(t => t.NewsID.Equals(pobj.NewsID));
                obj.NewsPicPath = pobj.ImagePath;
                return objContext.SaveChanges();
            }
        }

        public int EditDownloadInfo(bcDownload pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblDownload obj = new tblDownload();
                obj = objContext.tblDownloads.First(t => t.DownloadID.Equals(pobj.DownloadID));
                obj.DownloadTitle = pobj.Title;
                obj.Details = pobj.Details;
                obj.IsActive = pobj.IsActive;
                return objContext.SaveChanges();
            }
        }

        public int EditDownloadFile(bcDownload pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblDownload obj = new tblDownload();
                obj = objContext.tblDownloads.First(t => t.DownloadID.Equals(pobj.DownloadID));
                obj.DownloadPath = pobj.DownloadPath;               
                return objContext.SaveChanges();
            }
        }


        public int EditGalleryInfo(bcGallery pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblGallery obj = new tblGallery();
                obj = objContext.tblGalleries.First(t => t.GalleryID.Equals(pobj.GalleryID));
                obj.GalleryTitle = pobj.Title;
                obj.GalleryDescription = pobj.Detail;
                obj.IsActive = true;
              
                return objContext.SaveChanges();
            }
        }       

        public int EditGalleryPic(bcGallery pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblGallery obj = new tblGallery();
                obj = objContext.tblGalleries.First(t => t.GalleryID.Equals(pobj.GalleryID));
                obj.GalleryImage = pobj.ImagePath;
                return objContext.SaveChanges();
            }
        }       
        
        # endregion


    


    }
}
