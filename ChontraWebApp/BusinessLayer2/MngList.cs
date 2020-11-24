using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer2.CustomModels;

namespace BusinessLayer2
{
    public class MngList
    {
        private ChontraDBEntities objContext;

        # region Site
        public List<ClsMainModel.ClsPriceMenu> GetListofPriceMenu() //GetListofChairMessages()
        {
            using(objContext = new ChontraDBEntities())
            {
                return objContext.PriceMenus
                    .Where(dbr => dbr.isActive.Equals(true))
                    .Select(dbr => new ClsMainModel.ClsPriceMenu {
                        PriceMenuID = dbr.PriceMenuID,
                        PriceMenuTitle = dbr.PriceMenuTitle,
                        Price = dbr.Price,
                        PriceMenuPicture = dbr.PriceMenuPicture,
                        FoodName1 = dbr.FoodName1,
                        FoodName2 = dbr.FoodName2,
                        FoodName3 = dbr.FoodName3,
                        FoodName4 = dbr.FoodName4,
                        FoodName5 = dbr.FoodName5,
                        FoodName6 = dbr.FoodName6,
                        FoodName7 = dbr.FoodName7,
                        FoodName8 = dbr.FoodName8,
                        FoodName9 = dbr.FoodName9,
                        FoodName10 = dbr.FoodName10,
                        FoodName11 = dbr.FoodName11,
                        FoodName12 = dbr.FoodName12,
                        FoodName13 = dbr.FoodName13,
                        FoodName14 = dbr.FoodName14,
                        FoodName15 = dbr.FoodName15,
                        FoodName16 = dbr.FoodName16,
                        FoodName17 = dbr.FoodName17,
                        FoodName18 = dbr.FoodName18,
                        FoodName19 = dbr.FoodName19,
                        FoodName20 = dbr.FoodName20,
                    }).ToList();
            }
        }

       
        //public List<bcCabinet> GetListofMembers()
        //{
        //    List<bcCabinet> cablist = new List<bcCabinet>();
        //    using(objContext = new dbSiteEntities())
        //    {
        //        cablist = objContext.tblTeamMembers.Select(t => new bcCabinet { CabinetID = t.MemID, CabinetName = t.MemberName,DesignationName = t.Designation,IsActive = t.IsActive, ImagePath = t.ImagePath }).ToList();
                
                
        //    }

        //    return cablist;
        //}

        //public List<bcTestimonial> GetListofTestimonials()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblTestimonials.Where(tt => tt.IsActive.Equals(true)).Select(t => new bcTestimonial { TestiID = t.TestimonialID, Name = t.Name, Detail = t.Details, ImagePath = t.PicPath, IsActive = t.IsActive, Rating = t.Rating.Value }).Take(4).OrderByDescending(t => t.TestiID).ToList();
        //    }
        //}

        //public List<bcTestimonial> GetListofInActiveTestimonials()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblTestimonials.Where(tt => tt.IsActive.Equals(false)).Select(t => new bcTestimonial { TestiID = t.TestimonialID, Name = t.Name, Detail = t.Details, ImagePath = t.PicPath, IsActive = t.IsActive, Rating = t.Rating.Value }).ToList();
        //    }
        //}


        //public List<tblTestimonial> GetListoftblTestimonials()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblTestimonials.Where(t => t.IsActive.Equals(false)).OrderByDescending(t => t.TestimonialID).ToList();
        //    }
        //}

        ////public List<bcGallery> GetListofGallery()
        ////{
        ////    using (objContext = new dbSiteEntities())
        ////    {
        ////        return objContext.tblGalleries.Select(g => new bcGallery { GalleryID = g.GalleryID, Title = g.GalleryTitle, Detail = g.GalleryDescription, ImagePath = g.GalleryImage, IsActive = g.IsActive }).ToList();

        ////    }
        ////}

        //public List<tblGallery> GetListofGallery()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblGalleries.Where(g => g.IsActive.Equals(true)).OrderByDescending(g=> g.GalleryID).Take(10).ToList();
        //        //.Select(g => new { GalleryID = g.GalleryID, GalleryTitle = g.GalleryTitle, GalleryDescription = g.GalleryDescription, IsActive = g.IsActive });
        //    }
        //}

        //public List<tblQuote> GetListofQuote()
        //{
        //    using(objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblQuotes.Where(o=> o.isActive == true).OrderByDescending(o => o.QuoteID).ToList();                   
        //    }
        //}

        //public List<tblQuote> GetListofRcvdQuotes()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblQuotes.Where(o => o.IsRecieved == 0).OrderByDescending(o => o.QuoteID).ToList();
        //    }
        //}

        //public List<tblQuote> GetListofDeActiveQuote()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblQuotes.Where(o => o.isActive == false && o.IsRecieved == 0).OrderByDescending(o => o.QuoteID).ToList();
        //    }
        //}

        //public List<bcAboutMessage> GetListofAboutMessages()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblTexts.Where(t => t.TextType_ID == 10).Select(t => new bcAboutMessage { MessageID = t.TextID, MessageTitle = t.TextTitle, MessageDetails = t.TextDetail, MessageActive = t.IsActive}).ToList();
        //    }
        //}

        ////Slider
        //public List<bcSlider> GetListofSlider()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblSliders.Select(t => new bcSlider { SliderID = t.SliderID, Cap1 = t.SliderCap1, Cap2 = t.SliderCap2, Cap3 = t.SliderCap3, ImagePath = t.SliderImage }).ToList();
        //    }
        //}

        //public List<tblNew> GetListofNews()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblNews.Where(o=> o.IsActive == true).OrderByDescending(o => o.NewsID).ToList();
        //    }
        //}

        //public List<tblJob> GetAllJobs(int n)
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblJobs.Where(o=> o.IsActive.Value.Equals(true)).OrderByDescending(o => o.JobID).Take(n).ToList();
        //    }
        //}


        //public List<tblJob> GetListofJobs(bool status)
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblJobs.Where(o => o.IsActive == status).OrderByDescending(o => o.JobID).ToList();
        //    }
        //}

        //public List<tblJob> GetListofOpenJobs()  // for jobs page on website
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblJobs.Where(j=> j.ClosingDate >= DateTime.Now && j.IsActive.Value.Equals(true)).OrderByDescending(o => o.JobID).ToList();
        //    }
        //}

        //public List<tblApplication> GetListofApplicationsforJob(int jid)
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblApplications.Where(a => a.Job_ID.Equals(jid)).OrderByDescending(o => o.Job_ID).ToList();
                    
        //    }
        //}

        //public List<tblClient> GetListofClients()
        //{
        //    using(objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblClients.Where(c=> c.IsActive.Value.Equals(true)).OrderByDescending(o=> o.ClientID).Take(10).ToList();
        //    }
        //}

        //public List<tblDownload> GetListofDownloads()
        //{
        //    using (objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblDownloads.Where(c => c.IsActive.Equals(true)).OrderByDescending(o => o.DownloadID).Take(10).ToList();
        //    }
        //}

        # endregion

    }
}
