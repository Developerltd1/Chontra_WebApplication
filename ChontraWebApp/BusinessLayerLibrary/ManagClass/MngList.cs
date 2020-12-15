using BusinessLayerLibrary;
using BusinessLayerLibrary.CustomModels;
using BusinessLayerLibrary.ViewModel;
using MyCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayerLibrary
{
    public class MngList
    {
        private Entities objContext;
        public static string ExceptionMsg;

        # region Site
        public List<CustomModels.ClsMainModel.ClsPriceMenu> GetListofPriceMenuDistinct() 
        {
            using(objContext = new Entities())
            {
                var result = (from m in objContext.PriceMenu
                              where m.isActive == true
                              select new CustomModels.ClsMainModel.ClsPriceMenu
                              {
                                PriceMenuID = m.PriceMenuID,
                                PriceMenuTitle = m.PriceMenuTitle,
                                Price = m.Price,
                                PriceMenuPicture = m.PriceMenuPicture,
                              }).Distinct().ToList();
                return result;
            }
        }
        public List<CustomModels.ClsMainModel.ClsSubMenu> GetListofSubMenu()
        {
            using (objContext = new Entities())
            {
                var result = (from sm in objContext.SubMenu
                              where sm.isActive == true
                              select new CustomModels.ClsMainModel.ClsSubMenu
                              {
                                SubMenuID = sm.SubMenuID,
                                SubMenuTitle = sm.SubMenuTitle,
                                PriceMenu_ID = sm.PriceMenu_ID,
                              }).ToList();
                return result;
            }
        }

        public List<ClsMainModel.ClsServices> GetListofServices()
        { 
            using (objContext = new Entities())
            {
                return objContext.Services
                    .Where(dbr => dbr.isActive.Equals(true))
                    .Select(dbr => new ClsMainModel.ClsServices
                    {
                        ServicesID = dbr.ServicesID,
                        ServicesTitle = dbr.ServicesTitle,
                        ServicesDescription = dbr.ServicesDescription,
                        ServicesMainImage = dbr.ServicesMainImage
                    }).ToList();
            }
        }
        public List<ClsMainModel.ClsServicesPicture> GetListofServicesPictures()
        {
            using (objContext = new Entities())
            {
                return objContext.ServicesPicture
                    .Where(dbr => dbr.isActive.Equals(true))
                    .Select(dbr => new ClsMainModel.ClsServicesPicture
                    {
                        ServicesPictureTitle = dbr.ServicesPictureTitle,
                        ServicesPictureDescription = dbr.ServicesPictureDescription,
                        ServicesPicturePath = dbr.ServicesPicturePath
                    }).ToList();
            }
        }
        public List<ClsMainModel.ClsServicesPicture> GetListofDistinctServicesPictures()
        {
            using (objContext = new Entities())
            {
                return objContext.ServicesPicture
                    .Where(dbr => dbr.isActive.Equals(true))
                    .Select(dbr => new ClsMainModel.ClsServicesPicture
                    {
                        ServicesPictureTitle = dbr.ServicesPictureTitle,
                        ServicesPicturePath = dbr.ServicesPicturePath
                    }).Distinct().ToList();
            }
        }

        public static List<ClsMainModel.ClsEventType> GetListofEventType(int _EventTypeID)
        {
            using (Entities  objContext = new Entities())
            {
               var a = objContext.EventType
                    .Where(dbr => dbr.isActive.Equals(true) && dbr.EventTypeID == _EventTypeID)
                    .Select(dbr => new ClsMainModel.ClsEventType
                    {
                        EventTypeID = dbr.EventTypeID,
                        EventType = dbr.EventType1
                    }).ToList();

                return a;
            }
        }
        public  List<ViewModel.MainViewModels.ServicesPicture_N_EventTypeViewModels> GetListofServicesPicture(int ServicessID)
        {
            using (Entities objContext = new Entities())
            {
                #region Method1
                //var result = (from sp in objContext.ServicesPictures
                //              join et in objContext.EventTypes on sp.EventType_ID equals et.EventTypeID  
                //              join s in objContext.Services on sp.Services_ID equals s.ServicesID
                //              where sp.isActive == true
                //              select new
                //              {
                //                sp.Services_ID,
                //                s.ServicesTitle,
                //                sp.EventType_ID,
                //                et.EventType1,
                //                sp.ServicesPictureID,
                //                sp.ServicesPictureTitle,
                //                sp.ServicesPicturePath,
                //              }).ToList();
                //return result;
                #endregion

                #region Method2

                var result = (from sp in objContext.ServicesPicture
                             // join et in objContext.EventTypes on sp.EventType_ID equals et.EventTypeID
                              where sp.isActive == true //&& sp.Services_ID == ServicessID
                              
                              select new ViewModel.MainViewModels.ServicesPicture_N_EventTypeViewModels
                              { 
                                // EventType = et.EventType1,
                                // EventType_ID = sp.EventType_ID,
                                 ServicesPictureID = sp.ServicesPictureID,
                                 ServicesPictureTitle = sp.ServicesPictureTitle,
                                 ServicesPictureDescription = sp.ServicesPictureDescription,
                                 ServicesPicturePath = sp.ServicesPicturePath,
                              })
                              .ToList();
                return result;
                #endregion

            }
        }

        public List<ClsMainModel.ClsEventType> EventTypeDistinct(int ServicessID)
        {
            using (Entities objContext = new Entities())
            {
                #region Method2

                var result = (from sp in objContext.ServicesPicture
                             // join et in objContext.EventTypes on sp.EventType_ID equals et.EventTypeID
                              where sp.isActive == true //&& sp.Services_ID == ServicessID

                              select new ClsMainModel.ClsEventType
                              {
                               //  EventTypeID = sp.EventType_ID,
                                // EventType  =et.EventType1
                              })
                              .Distinct()
                              .ToList();
                return result;
                #endregion

            }
        }


        public List<ClsMainModel.ClsEvent> GetListofEvent()
        {
            using (Entities objContext = new Entities())
            {

                var result = objContext.HallEvent
                             .Where(dbr => dbr.isActive.Equals(true))
                             .Select(dbr => new ClsMainModel.ClsEvent
                             {
                                 EventID = dbr.EventID,
                                 EventTitle = dbr.EventTitle,
                                 EventDescription = dbr.EventDescription,
                                 EventMainPicture = dbr.EventMainPicture
                             }).ToList();
                return result;
            }
        }
        public List<MainViewModels.Gallery_N_GalleryDetilsViewModels> GetListofEventGalleryByEventID(int _EventID)
        {
            using (Entities objContext = new Entities())
            {

                var result = (from eg in objContext.HallEventGallery
                              join e in objContext.HallEvent on eg.Event_ID equals e.EventID
                              where eg.isActive == true && eg.Event_ID == _EventID
                              select new ViewModel.MainViewModels.Gallery_N_GalleryDetilsViewModels
                              {
                                 EventGalleryID = eg.EventGalleryID,
                                 EventGalleryTitle = eg.EventGalleryTitle,
                                 EventGalleryPicture = eg.EventGalleryPicturePath,
                                 EventTitle= e.EventTitle
                              }).ToList();
               
                #region Method 1 Joins
                //ClsMainModel.ClsEventGallery m = new ClsMainModel.ClsEventGallery();
                //var result = objContext.EventGalleries
                //.Where(dbr => dbr.isActive.Equals(true) && dbr.Event_ID.Equals(_EventID))
                //.Select(dbr => new ClsMainModel.ClsEventGallery
                //{
                //EventGalleryID = dbr.EventGalleryID,
                //EventGalleryTitle = dbr.EventGalleryTitle,
                //EventGalleryPicture = dbr.EventGalleryPicturePath,
                //})
                //.Join(objContext.Events,
                //egKey => egKey.Event_ID,
                //eKey => eKey.EventID,
                //(egKey, eKey) => new
                //{ m.Event_ID = eKey.EventID }
                //).ToList();
                #endregion
                return result;
            }
        }
        public List<ClsMainModel.ClsSlider> GetListofSliderHome()
        {
            using (Entities objContext = new Entities())
            {
                var result = objContext.Slider
                             .Where(dbr => dbr.isActive.Equals(true) && dbr.SelecPage == "HomePage")
                             .Select(dbr => new ClsMainModel.ClsSlider
                             {
                                 SliderID = dbr.SliderID,
                                 SliderTitle = dbr.SliderTitle,
                                 SliderDecription = dbr.SliderDecription,
                                 SliderImagePath = dbr.SliderImagePath
                             }).ToList();
                return result;
            }
        }
        public List<ClsMainModel.ClsSlider> GetListofSliderAboutPage()
        {
            using (Entities objContext = new Entities())
            {
                var result = objContext.Slider
                             .Where(dbr => dbr.isActive.Equals(true))
                             .Select(dbr => new ClsMainModel.ClsSlider
                             {
                                 SliderID = dbr.SliderID,
                                 SliderTitle = dbr.SliderTitle,
                                 SliderDecription = dbr.SliderDecription,
                                 SliderImagePath = dbr.SliderImagePath,
                             }).ToList();
                return result;
            }
        }

        //StoreProcedure
        public List<GeEventByDate_Result> GetListofEventTiming()
        {
            using (Entities objContext = new Entities())
            {
                List<GeEventByDate_Result> data =null;// objContext.Database.SqlQuery<GeEventByDate_Result>("GeEventByDate").ToList();
                return data;
            }
           
        }

        public List<MainViewModels.User_N_RoleViewModels> GetListofUsers()
        {
            using (Entities objContext = new Entities())
            {
                var result = (from u in objContext.Membership_Users
                              join r in objContext.Membership_RoleUsers on u.Role_ID equals r.RoleID
                              where u.IsActive == true
                              select new ViewModel.MainViewModels.User_N_RoleViewModels
                              {
                                  FullName = u.FullName,
                                  Image = u.Image,
                                  RoleName = r.RoleName,
                                  Description = r.Description,
                              }).ToList();
                return result;
            }
        }
        public List<ClsMainModel.ClsContact> GetEmail_N_Contact()
        {
            using (Entities objContext = new Entities())
            {
                var result = objContext.Contact
                             .Where(dbr => dbr.isActive.Equals(true))
                             .Select(dbr => new ClsMainModel.ClsContact
                             {
                                 ContactID = dbr.ContactID,
                                 ContactOurPhone = dbr.ContactOurPhone,
                                 ContactEmail = dbr.ContactEmail
                             }).ToList();
                return result;
            }
        }
        public ClsMainModel.ClsBranch GetListofBranch(int BranchID)
        {
            using (Entities objContext = new Entities())
            {
                var result = objContext.Branch
                             .Where(dbr => dbr.isActive.Equals(true) && dbr.BranchID == BranchID)
                             .Select(dbr => new  ClsMainModel.ClsBranch
                             {
                                 BranchID = dbr.BranchID,
                                 BranchName = dbr.BranchName,
                                 BranchContact = dbr.ContactNumber,
                                 BranchAddress = dbr.BranchAddress,
                                 LogoPath = dbr.LogoPath,
                             }).SingleOrDefault();
                return result;

            }
        }
        public ClsMainModel.ClsContact GetListofContact()
        {
            using (Entities objContext = new Entities())
            {
                var result = objContext.Contact
                             .Where(dbr => dbr.isActive.Equals(true))
                             .Select(dbr => new ClsMainModel.ClsContact
                             {
                                 ContactID = dbr.ContactID,
                                 ContactName = dbr.ContactName,
                                 ContactMessage = dbr.ContactMessage,
                                 ContactDescription = dbr.ContactDescription,
                                 ContactEmail = dbr.ContactEmail,
                                 ContactAddress = dbr.ContactAddress,
                                 ContactPhone = dbr.ContactPhone,
                                 ContactMobile1 = dbr.ContactMobile1,
                                 ContactMobile2 = dbr.ContactMobile2,

                             }).SingleOrDefault();
                return result;

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

        #endregion

        #region Admin

        //StoreProcedure
        public List<Admin_GetAllCustomer_Result> Admin_GetAllCustomer()
        {
            using (Entities objContext = new Entities())
            {
                var data = objContext.Database.SqlQuery<Admin_GetAllCustomer_Result>("Admin_GetAllCustomer").ToList();
                return data;
            }

        }

        public  DataTable Admin_GetCustomerInfoByReciptNo(int ReciptNo)
        {

            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Admin_GetCustomerInfoByReciptNo", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@ReciptNo", ReciptNo);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();


                return dt;
            }
            catch (Exception ex)
            {
                ExceptionMsg = ex.Message;
                //Return Value
                return dt;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }

        public DataTable Admin_DisplaySlider()
        {
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Slider", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);
            con.Close();

            con.Dispose();
            cmd.Dispose();

            return dt;
        }
        public  List<ClsMainModel.ClsPriceMenu> Admin_GetPriceMenu()
        {

            List<ClsMainModel.ClsPriceMenu> lst = new List<ClsMainModel.ClsPriceMenu>();
            // DataTable Declaration
            DataTable dt = new DataTable();

            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ChontraConnectionString"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Admin_GetPriceMenu", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);


                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
               lst = Conversion.ConvertDataTable<ClsMainModel.ClsPriceMenu>(dt);
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionMsg = ex.Message;
                //Return Value
                return lst;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }

        #endregion


        #region Combo

        #endregion
    }
}
