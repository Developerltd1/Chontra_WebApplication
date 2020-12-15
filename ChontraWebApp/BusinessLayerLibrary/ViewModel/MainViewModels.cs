using BusinessLayerLibrary.CustomModels;
using System;
using System.Collections.Generic;

namespace BusinessLayerLibrary.ViewModel
{
    public class MainViewModels
    {
       
        public ClsMainModel.ClsEventType vmSingleClsEventType  { get; set; }
        public ClsMainModel.ClsServicesPicture vmSingleServicesPicture { get; set; }
        public ClsMainModel.ClsServices vmSingleClsServices { get; set; }
        public ServicesPicture_N_EventTypeViewModels vmSinglePicture_N_EventTypeViewModels { get; set; }

        public List<ServicesPicture_N_EventTypeViewModels> vmListPicture_N_EventTypeViewModels { get; set; }
        public List<ClsMainModel.ClsEventType> vmListClsEventType { get; set; }
        public List<ClsMainModel.ClsPriceMenu> vmListClsPriceMenu { get; set; }
        public List<ClsMainModel.ClsSubMenu> vmListClsSubMenu { get; set; }
        public List<ClsMainModel.ClsPriceMenu> vmListPriceMenu_N_SubMenu { get; set; }

        public  EventType_N_Services_N_ServicesPictureViewModels vmSingleClsEventType_N_Services_N_ServicesPictureViewModels { get; set; }
        public List<EventType_N_Services_N_ServicesPictureViewModels> vmListClsEventType_N_Services_N_ServicesPictureViewModels { get; set; }


        public class ServicesNSubServicesNServicesPicture_ViewModels
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
            public int ServicesID { get; set; }
               
                public int ModifyByUser_ID { get; set; }
                public DateTime ModifyDate { get; set; }
                public string ServicesTitle { get; set; }
                public string ServicesDescription { get; set; }
                public string ServicesMainImage { get; set; }
           
                public int ServicesPictureID { get; set; }
                public int SubServices_ID { get; set; }
                public string ServicesPictureTitle { get; set; }
                public string ServicesPictureDescription { get; set; }
                public string ServicesPicturePath { get; set; }
           
                public int SubServiceID { get; set; }
                public int Service_ID { get; set; }
                public int EventType_ID { get; set; }
                public string SubServiceTitle { get; set; }

            public int EventTimingID { get; set; }
            public int Customer_ID { get; set; }
            public int ServicesPicture_ID { get; set; }
            public DateTime EventDateTime { get; set; }
            public DateTime CreatedDateTime { get; set; }
            public DateTime ModifiedDateTime { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal Advance { get; set; }
            public decimal Balance { get; set; }

            
                public int EventTimingTypeID { get; set; }
              
                public string EventTimingType { get; set; }
        


        }



        public class EventTiming_N_Customer_N_ServicesPicture_N_EventType_N_ServicesViewModels
        {
            public int CustomerID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public DateTime EntryDate { get; set; }
            public bool isActive { get; set; }
            public string CustomerName { get; set; }
            public string CustomerConact { get; set; }
            public string CustomerCNIC { get; set; }
            public string CustomerAddress { get; set; }

            public int ServicesPictureID { get; set; }
            public int Services_ID { get; set; }
            public int EventType_ID { get; set; }
            public string ServicesPictureTitle { get; set; }
            public string ServicesPictureDescription { get; set; }
            public string ServicesPicturePath { get; set; }

            public int EventTypeID { get; set; }
            public int ModifyByUser_ID { get; set; }
            public DateTime ModifyDate { get; set; }
            public string EventType { get; set; }

            public int ServicesID { get; set; }
            public DateTime CreatedDate { get; set; }
            public string ServicesTitle { get; set; }
            public string ServicesDescription { get; set; }
            public string ServicesMainImage { get; set; }

            public int SubServiceID { get; set; }
            public int Service_ID { get; set; }
            public string SubServiceTitle { get; set; }

            public int PriceMenuID { get; set; }
            public long Price { get; set; }
            public string PriceMenuTitle { get; set; }
            public string PriceMenuPicture { get; set; }
            public int SubMenu_ID { get; set; }
        }

        public class ServicesPicture_N_EventTypeViewModels
        {
            public int EventTypeID { get; set; }
            public int EventType_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifyByUser_ID { get; set; }
            public DateTime EntryDate { get; set; }
            public DateTime ModifyDate { get; set; }
            public string EventType { get; set; }
            public int ServicesPictureID { get; set; }
            public bool isActive { get; set; }
            public string ServicesPictureTitle { get; set; }
            public string ServicesPictureDescription { get; set; }
            public string ServicesPicturePath { get; set; }
        }

        public class EventType_N_Services_N_ServicesPictureViewModels
        {
            public int EventTypeID { get; set; }
            public int EventType_ID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifyByUser_ID { get; set; }
            public DateTime EntryDate { get; set; }
            public DateTime ModifyDate { get; set; }
            public string EventType { get; set; }


            public int ServicesID { get; set; }
            public DateTime CreatedDate { get; set; }
            public string ServicesTitle { get; set; }
            public string ServicesDescription { get; set; }
            public string ServicesMainImage { get; set; }


            public int ServicesPictureID { get; set; }
            public bool isActive { get; set; }
            public string ServicesPictureTitle { get; set; }
            public string ServicesPictureDescription { get; set; }
            public string ServicesPicturePath { get; set; }
        }
        public class Gallery_N_GalleryDetilsViewModels
        {
           
                public int EventID { get; set; }
                public string EventTitle { get; set; }
                public string EventDescription { get; set; }
                public string EventMainPicture { get; set; }
         
                public int EventGalleryID { get; set; }
                public bool isActive { get; set; }
                public string EventGalleryTitle { get; set; }
                public string EventGalleryPicture { get; set; }
                public int Event_ID { get; set; }
        }
        public class PriceMenu_N_SubMenuViewModels
        {
            public int SubMenuID { get; set; }
            public int CreatedByUser_ID { get; set; }
            public int ModifiedByUser_ID { get; set; }
            public int PriceMenu_ID { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
            public bool isActive { get; set; }
            public string SubMenuTitle { get; set; }


            public int PriceMenuID { get; set; }
            public long Price { get; set; }
            public string PriceMenuTitle { get; set; }
            public string PriceMenuPicture { get; set; }
            public int SubMenu_ID { get; set; }

        }
        public class User_N_RoleViewModels
        {
                public DateTime CreatedDate { get; set; }
                public DateTime UpdatedDate { get; set; }
                public int RoleID { get; set; }
                public int CreatedBy { get; set; }
                public int UpdatedBy { get; set; }
                public bool IsActive { get; set; }
                public string RoleName { get; set; }
             public string Description { get; set; }

            public Guid UserKey { get; set; }
                public int UserID { get; set; }
                public int Role_ID { get; set; }
                public string FullName { get; set; }
                public string UserName { get; set; }
                public string Email { get; set; }
                public string Password { get; set; }
                public string ContactNo { get; set; }
                public string Address { get; set; }
                public string MobileNumber { get; set; }
                public string Image { get; set; }
        }
        public class Branch_N_ContactPageViewModels
        {
            public int BranchID { get; set; }
            public string BranchName { get; set; }
            public string BranchContact { get; set; }
            public string LogoPath { get; set; }
            public string isActive { get; set; }

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
            public string ContactDescription { get; set; }
            public string ContactOurPhone { get; set; }
            public string ContactMobile1 { get; set; }
            public string ContactMobile2 { get; set; }
        }
    }
}

