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
    public class bcConfrence
    {
        [DisplayName("ID")] 
        public int ConfrenceID { get; set; }
          [DisplayName("Title")] 
        public string ConfrenceTitle { get; set; }
        [DisplayName("Details")] 
        public string ConfrenceDetails { get; set; }
        [DisplayName("Country")] 
        public string ConfrenceCountry { get; set; }
        [DisplayName("City")] 
        public string ConfrenceCity { get; set; }
        [DisplayName("Address")] 
        public string ConfrenceAddress { get; set; }
        [DisplayName("UploadDate")]
        public DateTime? ConfrenceUploadDate { get; set; }
        [DisplayName("StartDate")]
        public DateTime? ConfrenceStartDate { get; set; }
        [DisplayName("EndDate")] 
        public DateTime? ConfrenceEndDate { get; set; }
       
        [DisplayName("Type")] 
        public int ConfrenceType { get; set; }
        public int uid { get; set; }

        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}
