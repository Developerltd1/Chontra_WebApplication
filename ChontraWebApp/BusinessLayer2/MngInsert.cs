using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer2.CustomModels;
using System.Globalization;

namespace BusinessLayer2
{
    public class MngInsert
    {
        dbSiteEntities objContext; 

        # region Site
        public int InsertNewChiefMessage(bcChiefMessage pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                
                tblText obj = new tblText();
                obj.TextTitle = pobj.MessageTitle;
                obj.TextDetail = pobj.MessageDetails;
                obj.TextPage = "Home";
                obj.TextType_ID = pobj.TextType;
                obj.EnterBy_ID = pobj.uid;
                obj.EntryDate = DateTime.Now;
                obj.IsActive = true;
                pobj.ImagePath = null;
                objContext.tblTexts.Add(obj);
                objContext.SaveChanges();
                return obj.TextID;
            }

        }

        public int InsertChiefImage(bcChiefMessage pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                obj = objContext.tblTexts.First(t => t.TextID.Equals(pobj.MessageID));
                obj.ImagePath = pobj.ImagePath;                   
                return objContext.SaveChanges();
            }

        }

        public int InsertNewNews(bcNews pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblNew obj = new tblNew();
                
                obj.NewsDescription = pobj.NewsDetails;
                obj.EnterBy_ID = pobj.uid;
                obj.EntryDate = DateTime.Now;
                obj.IsActive = pobj.IsActive;
                objContext.tblNews.Add(obj);
                return objContext.SaveChanges();
            }

        }

        public int InsertNewsPicture(bcNews pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblNew obj = new tblNew();
                obj = objContext.tblNews.First(t => t.NewsID.Equals(pobj.NewsID));
                obj.NewsPicPath = pobj.ImagePath;
                return objContext.SaveChanges();
            }

        }
        public int InsertNewMember(bcCabinet pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTeamMember obj = new tblTeamMember(); 

                obj.MemberName = pobj.CabinetName;
                //obj.Qualification = pobj.Qualification;
                obj.Designation = pobj.DesignationName;
                //obj.JobDetails = pobj.JobDetails;
                //obj.EducationDetails = pobj.EduDetails;
                //obj.MemberAddress = pobj.Address;
                //obj.MemberContactNo = pobj.Contactno;
                //obj.MemberEmail = pobj.Email;
                obj.ImagePath = pobj.ImagePath;
                obj.IsActive = true;
                obj.EntryDate = DateTime.Now;
                obj.EnterBy_ID = pobj.uid;
                
                objContext.tblTeamMembers.Add(obj);
                if (objContext.SaveChanges() > 0)
                {                   
                    return obj.MemID;
                }
                else
                    return 0;
            }

        }
      
        public int InsertMemberPicture(bcCabinet pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTeamMember obj = new tblTeamMember();
                obj = objContext.tblTeamMembers.First(t => t.MemID.Equals(pobj.CabinetID));
                obj.ImagePath = pobj.ImagePath;
                return objContext.SaveChanges();
            }
        }

        public int InsertCustomerQuote(bcQuote pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblQuote obj = new tblQuote();
                //obj.ToLoc = pobj.ToLoc;
                //obj.FromLoc = pobj.FromLoc;
                obj.Name = pobj.Name;
                obj.Organization = pobj.Organization;
                obj.QuoteType = pobj.QuoteType;
                obj.MobileNo = pobj.MobileNo;                
                obj.Address = pobj.Address;                
                obj.ContactNo = pobj.Contactno;
                obj.Email = pobj.Email;
                obj.Details = pobj.Details;
                obj.EntryDate = DateTime.Now;
                obj.isActive = true;
                obj.IsRecieved = 0;  // ) means submitted but not checked yet
                obj = objContext.tblQuotes.Add(obj);   
                return objContext.SaveChanges();
            }
        }

        public int InsertNewAboutMessage(bcAboutMessage pobj)
        {
            using (objContext = new dbSiteEntities())
            {

                tblText obj = new tblText();
                obj.TextTitle = pobj.MessageTitle;
                obj.TextDetail = pobj.MessageDetails;
                obj.TextPage = "About";
                obj.TextType_ID = pobj.TextType;
                obj.EntryDate = DateTime.Now;
                obj.IsActive = true;
                obj.EnterBy_ID = pobj.uid;
                objContext.tblTexts.Add(obj);
                objContext.SaveChanges();
                return obj.TextID;
            }

        }

        public int InsertNewSlider(bcSlider pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblSlider obj = new tblSlider();
                obj.SliderImage = ""; // pobj.ImagePath;
                obj.SliderCap1 = pobj.Cap1;
                obj.SliderCap2 = String.Empty;
                obj.SliderCap3 = String.Empty;
                //pobj.ImagePath = "PathEmpty";
                obj.EnterBy_ID = 1;//pobj.uid;
                obj.EntryDate = DateTime.Now;

                objContext.tblSliders.Add(obj);
                objContext.SaveChanges();

                return obj.SliderID;
            }
        }
        public int InsertSliderImage(bcSlider pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblSlider obj = new tblSlider();
                obj = objContext.tblSliders.First(t => t.SliderID.Equals(pobj.SliderID));
                obj.SliderImage = pobj.ImagePath;
                return objContext.SaveChanges();
            }

        }

        public int InsertGalleryImage(bcGallery pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblGallery obj = new tblGallery();
                obj = objContext.tblGalleries.First(t => t.GalleryID.Equals(pobj.GalleryID));
                obj.GalleryImage = pobj.ImagePath;
                return objContext.SaveChanges();
            }

        }

        public int InsertNewTestimonial(bcTestimonial pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTestimonial obj = new tblTestimonial();
                obj.PicPath = ""; // pobj.ImagePath;
                obj.Name = pobj.Name;
                obj.Details = pobj.Detail;
                obj.IsActive = true;
                //pobj.ImagePath = "PathEmpty";
                //obj.EnterBy_ID = 1;//pobj.uid;
                //obj.EntryDate = DateTime.Now;

                objContext.tblTestimonials.Add(obj);
                objContext.SaveChanges();

                return obj.TestimonialID;
            }
        }
        public int InsertTestiImage(bcTestimonial pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblTestimonial obj = new tblTestimonial();
                obj = objContext.tblTestimonials.First(t => t.TestimonialID.Equals(pobj.TestiID));
                obj.PicPath = pobj.ImagePath;
                return objContext.SaveChanges();
            }

        }
  
        public int InsertNewJob (bcJob pobj)
        {
            tblJob obj = new tblJob();
            using(objContext = new dbSiteEntities())
            {
                string s = pobj.PostDate.Date.ToString();
                obj.JobTitle = pobj.JobTitle;
                obj.PostDate = DateTime.ParseExact(pobj.SPostDate,"dd/MM/yyyy",CultureInfo.InvariantCulture);
                
                obj.ClosingDate = DateTime.ParseExact(pobj.SCloseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj.Details = pobj.Details;
                obj.EntryDate = DateTime.Now;
                obj.EnterByUser_ID = pobj.EnterByUser_ID;
                obj.IsActive = true;
                obj.AdvPath = "";

                objContext.tblJobs.Add(obj);
                objContext.SaveChanges();

                return obj.JobID;
            }


        }

        public int InsertJobImage(bcJob pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblJob obj = new tblJob();
                obj = objContext.tblJobs.First(t => t.JobID.Equals(pobj.JobID));
                obj.AdvPath = pobj.ImagePath;
                return objContext.SaveChanges();
            }

        }

        public int InsertNewApplication(bcApplication pobj)
        {
            tblApplication obj = new tblApplication();
            using (objContext = new dbSiteEntities())
            {
                obj.Job_ID = pobj.jobid;
                obj.ApplicantName = pobj.Name;
                obj.CNIC = pobj.cnic;
                obj.ContactNo = pobj.ContactNo;
                obj.MobileNo = pobj.MobileNo;
                obj.Email = pobj.Email;
                obj.DomicileDistrict_ID = pobj.DomicileDistt;
                obj.Experience = pobj.Experience;
                
                obj.MailAddress = pobj.Address;
                
                obj.EntryDate = DateTime.Now;
                obj.EnterByUser_ID = pobj.EnterByUser_ID;
                obj.IsActive = true;
                obj.CVPath = "";

                objContext.tblApplications.Add(obj);
                objContext.SaveChanges();

                return obj.ApplicationID;
            }
        }

        public int InsertApplicantCV(bcApplication pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblApplication obj = new tblApplication();
                obj = objContext.tblApplications.First(t => t.ApplicationID.Equals(pobj.ApplicantID));
                obj.CVPath = pobj.CVPath;
                return objContext.SaveChanges();
            }

        }

        public int InsertNewClient(bcClient pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblClient obj = new tblClient();

                obj.ClientName = pobj.ClientName;
                obj.EnterByUser_ID = pobj.uid;
                obj.EntryDate = DateTime.Now;
                obj.ClientLogo = "";
                obj.IsActive = true;
                
                //obj.entr = DateTime.Now;
                //obj.EnterBy_ID = pobj.uid;

                objContext.tblClients.Add(obj);
                if (objContext.SaveChanges() > 0)
                {
                    return obj.ClientID;
                }
                else
                    return 0;
            }

        }

        public int InsertClientPicture(bcClient pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblClient obj = new tblClient();
                obj = objContext.tblClients.First(t => t.ClientID.Equals(pobj.ClientID));
                obj.ClientLogo = pobj.ImagePath;
                return objContext.SaveChanges();
            }
        }


        public int InsertNewDownload(bcDownload pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblDownload obj = new tblDownload();

                obj.DownloadTitle = pobj.Title;
                obj.Details = pobj.Details;
                obj.EnterByUser_ID = pobj.uid;
                obj.EntryDate = DateTime.Now;
                obj.DownloadPath = "";
                obj.IsActive = true;

                //obj.entr = DateTime.Now;
                //obj.EnterBy_ID = pobj.uid;

                objContext.tblDownloads.Add(obj);
                if (objContext.SaveChanges() > 0)
                {
                    return obj.DownloadID;
                }
                else
                    return 0;
            }

        }

        public int InsertDownloadFile(bcDownload pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblDownload obj = new tblDownload();
                obj = objContext.tblDownloads.First(t => t.DownloadID.Equals(pobj.DownloadID));
                obj.DownloadPath = pobj.DownloadPath;
                return objContext.SaveChanges();
            }
        }


        public int InsertNewGallery(bcGallery pobj)
        {
            using (objContext = new dbSiteEntities())
            {
                tblGallery obj = new tblGallery();

                obj.GalleryTitle = pobj.Title;
                obj.GalleryDescription = pobj.Detail;
                obj.EnterBy_ID = pobj.uid;
                obj.EntryDate = DateTime.Now;
                obj.GalleryImage = "";
                obj.IsActive = true;

                objContext.tblGalleries.Add(obj);
                if (objContext.SaveChanges() > 0)
                {
                    return obj.GalleryID;
                }
                else
                    return 0;
            }

        }

        public int InsertGalleryPic(bcGallery pobj)
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
