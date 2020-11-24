using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.CustomModels
{
    public class ClsMainModel
    {

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
            public int EventGallery_ID { get; set; }
            public byte[] EventTitle { get; set; }
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
            public string FoodName1 { get; set; }
            public string FoodName2 { get; set; }
            public string FoodName3 { get; set; }
            public string FoodName4 { get; set; }
            public string FoodName17 { get; set; }
            public string FoodName18 { get; set; }
            public string FoodName19 { get; set; }
            public string FoodName20 { get; set; }
            public string FoodName11 { get; set; }
            public string FoodName12 { get; set; }
            public string FoodName13 { get; set; }
            public string FoodName14 { get; set; }
            public string FoodName15 { get; set; }
            public string FoodName16 { get; set; }
            public string FoodName5 { get; set; }
            public string FoodName6 { get; set; }
            public string FoodName7 { get; set; }
            public string FoodName8 { get; set; }
            public string FoodName9 { get; set; }
            public string FoodName10 { get; set; }
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

        public class ClsServicesPicture
        {
            public int ServicesPictureID { get; set; }
            public bool isActive { get; set; }
            public string ServicesPictureTitle { get; set; }
            public string ServicesPictureDescription { get; set; }
            public string ServicesPicturePicture { get; set; }
        }

        #endregion

        #region Slider Class

        public class ClsSlider
        {
            public int SliderID { get; set; }
            public bool isActive { get; set; }
            public string SliderTitle { get; set; }
            public string SliderDecription { get; set; }
            public string SliderImagePath { get; set; }
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
