using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayerLibrary.CustomModels
{
    public class ClsMainModel
    {


        #region CustomerEventOrder Class

        public class ClsCustomerEventOrder
        {
            public int CustomerEventDetailsID { get; set; }
            public int Customer_ID { get; set; }
            public int Services_ID { get; set; }
            public int SubServices_ID { get; set; }
            public int EventType_ID { get; set; }
            public int EventTimingTypeID { get; set; }
            public int PriceMenu_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifiedByUser_ID { get; set; }
            public DateTime EntryDateTime { get; set; }
            public DateTime ModifiedByDateTime { get; set; }
            public bool isActive { get; set; }
            public decimal PerEventAmount { get; set; }
        }

        #endregion

        #region ServicesPicture Class

        public class ClsServicesPicture
        {
            public int ServicesPictureID { get; set; }
            public int Services_ID { get; set; }
            public int EventType_ID { get; set; }
            public bool isActive { get; set; }
            public string ServicesPictureTitle { get; set; }
            public string ServicesPictureDescription { get; set; }
            public string ServicesPicturePath { get; set; }
        }

        #endregion
        #region Customer Class

        public class ClsCustomer
        {
            public int CustomerID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public DateTime EntryDate { get; set; }
            public bool isActive { get; set; }
            public string CustomerName { get; set; }
            public string CustomerConact { get; set; }
            public string CustomerCNIC { get; set; }
            public string CustomerAddress { get; set; }
        }

        #endregion

        #region SubMenu Class

        public class ClsSubMenu
        {
            public int SubMenuID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifiedByUser_ID { get; set; }
            public int PriceMenu_ID { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
            public bool isActive { get; set; }
            public string SubMenuTitle { get; set; }
        }

        #endregion

        #region Contact Class
        public class ClsBranch
        {
            public int BranchID { get; set; }
            public string BranchName { get; set; }
            public string BranchAddress { get; set; }
            public string BranchContact { get; set; }
            public string LogoPath { get; set; }
            public string isActive { get; set; }
        }
        #endregion

        #region Contact Class

        public class ClsContact
        {
            public int ContactID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifiedByUser_ID { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime MidfiedDate { get; set; }
            public string ContactName { get; set; }
            public string ContactEmail { get; set; }
            public string ContactDescription { get; set; }
            public string ContactPhone { get; set; }
            public string ContactSubject { get; set; }
            public string ContactMessage { get; set; }
            public string ContactAddress { get; set; }
            public string ContactOurPhone { get; set; }
            public string ContactMobile1 { get; set; }
            public string ContactMobile2 { get; set; }
        }

        #endregion

        #region Event Class

        public class ClsEvent
        {
            public int EventID { get; set; }
            public string EventTitle { get; set; }
            public string EventDescription { get; set; }
            public string EventMainPicture { get; set; }
        }

        #endregion

        #region EventGallery Class

        public class ClsEventGallery
        {
            public int EventGalleryID { get; set; }
            public bool isActive { get; set; }
            public string EventGalleryTitle { get; set; }
            public string EventGalleryPicture { get; set; }
            public int Event_ID { get; set; }
        }

        #endregion

        #region EventType Class

        public class ClsEventType
        {
            public int EventTypeID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifyByUser_ID { get; set; }
            public DateTime EntryDate { get; set; }
            public DateTime ModifyDate { get; set; }
            public bool isActive { get; set; }
            public string EventType { get; set; }
        }

        #endregion

        #region Membership_Rolepages Class

        public class ClsMembership_Rolepages
        {
            public int RoleWebPageID { get; set; }
            public int Role_ID { get; set; }
            public int WebPage_ID { get; set; }
            public bool HasInsert { get; set; }
            public bool HasUpdate { get; set; }
            public bool HasDelete { get; set; }
        }

        #endregion

        #region Membership_RoleUsers Class

        public class ClsMembership_RoleUsers
        {
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
            public int RoleID { get; set; }
            public int CreatedBy { get; set; }
            public int UpdatedBy { get; set; }
            public bool IsActive { get; set; }
            public string RoleName { get; set; }
        }

        #endregion

        #region Membership_Users Class

        public class ClsMembership_Users
        {
            public Guid UserKey { get; set; }
            public int UserID { get; set; }
            public int Role_ID { get; set; }
            public bool IsActive { get; set; }
            public string FullName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ContactNo { get; set; }
            public string Address { get; set; }
            public string MobileNumber { get; set; }
            public string Image { get; set; }
        }

        #endregion

        #region Membership_Webpages Class

        public class ClsMembership_Webpages
        {
            public int WebPageID { get; set; }
            public int Parent_ID { get; set; }
            public int PageOrder { get; set; }
            public bool IsHorizantal { get; set; }
            public bool IsVisible { get; set; }
            public string AreaName { get; set; }
            public string ControllerName { get; set; }
            public string ViewName { get; set; }
            public string MenuTitle { get; set; }
            public string PageTitle { get; set; }
            public string Description { get; set; }
            public string MenuColor { get; set; }
            public string PageIcon { get; set; }
        }

        #endregion

        #region Membership_Webpageurls Class

        public class ClsMembership_Webpageurls
        {
            public int WebPageUrlID { get; set; }
            public int WebPage_ID { get; set; }
            public string Url { get; set; }
        }

        #endregion

        #region PriceMenu Class

        #region PriceMenu Class

        public class ClsPriceMenu
        {
            public int PriceMenuID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifiedByUser_ID { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
            public bool isActive { get; set; }
            public long Price { get; set; }
            public string PriceMenuTitle { get; set; }
            public string PriceMenuPicture { get; set; }
            public string PriceMenuPictureOnlyPath { get; set; }
            public int SubMenu_ID { get; set; }

        }

        #endregion

        #endregion

        #region Services Class

        public class ClsServices
        {
            public int ServicesID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifyByUser_ID { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifyDate { get; set; }
            public bool isActive { get; set; }
            public string ServicesTitle { get; set; }
            public string ServicesDescription { get; set; }
            public string ServicesMainImage { get; set; }
        }

        #endregion

        #region ServicesPicture Class

       // public class ClsServicesPicture
       // {
       //     public int ServicesPictureID { get; set; }
       //     public bool isActive { get; set; }
       //     public string ServicesPictureTitle { get; set; }
       //     public string ServicesPictureDescription { get; set; }
       //     public string ServicesPicturePath { get; set; }
       // }

        #endregion

        #region Slider Class

        public class ClsSlider
        {
            public int SliderID { get; set; }
            public bool isActive { get; set; }
            public bool isVideo { get; set; }
            public string SliderTitle { get; set; }
            public string SelectPage { get; set; }
            public string SliderDecription { get; set; }
            public string SliderImagePath { get; set; }
            public HttpPostedFileBase tmStor_ImageFile { get; set; }
        }

        #endregion

        #region Stages Class

        public class ClsStages
        {
            public int StageID { get; set; }
            public int EventType_ID { get; set; }
            public char StageTitle { get; set; }
            public char StageDescription { get; set; }
        }

        #endregion

    }
}
