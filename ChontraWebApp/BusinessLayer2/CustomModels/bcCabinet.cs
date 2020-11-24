using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BusinessLayer2.CustomModels
{
    public class bcCabinet
    {

        [DisplayName("Id")] 
        public int CabinetID { get; set; }
        
        [DisplayName("Name")]  
        [StringLength(25)]
        public string CabinetName { get; set; }
       
        [DisplayName("Designation")] 
        
        public string DesignationName { get; set; }
        
        [StringLength(25)]
        [DisplayName("Qualification")]  
        public string Qualification { get; set; }

        [StringLength(25)]
        [DisplayName("Email")]  
        public string Email { get; set; }

        [DisplayName("Picture")]  
        
        public string ImagePath { get; set; }

        [DisplayName("Designation")]  
        public int DesignationId { get; set; }

        [DisplayName("Education")]  
        public string EduDetails { get; set; }

        [DisplayName("Job")]  
        public string JobDetails { get; set; }

        //[DisplayName("Personal Details")]  
        //public string PersonDetails { get; set; }
        [StringLength(100)]
        [DisplayName("Address")]  
        public string Address { get; set; }

        [StringLength(15)]
        [DisplayName("Contact No")]  
        public string Contactno { get; set; }

        [DisplayName("Tenure Date")]  
        public DateTime StartDate { get; set; }

         [DisplayName("Active")]
        public bool IsActive { get; set; }

        [FileExtensions(Extensions = "png,jpg")]
        public HttpPostedFileBase ImageFile { get; set; }

        public int uid { get; set; }

    }
}
