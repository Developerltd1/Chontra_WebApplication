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
    public class bcApplication
    {
        public int ApplicantID { get; set; }
        public string Name { get; set; }
        
        [RegularExpression("^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        //[RegularExpression("^[0-9]{5}[0-9]{7}[0-9]$", ErrorMessage = "CNIC Num must follow the XXXXXXXXXXXXX format!")]
        public string cnic { get; set; }
        
        [Phone]
        public string ContactNo { get; set; }

        [Phone]
        public string MobileNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime DoB { get; set; }

        public char Gender { get; set; }

        [Range(0,50)]
        public float Experience { get; set; }
        public DateTime ApplyDate { get; set; }

        //[Required(ErrorMessage = "Image Error in Model")]
        [DisplayName("Upload Image:")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("Upload CV:")]
        
        [StringLength(20)]
        public string CVPath { get; set; }

       // [FileExtensions(Extensions = "doc,docx,pdf")]
        public HttpPostedFileBase CVFile { get; set; }

        public int DomicileDistt { get; set; }
        public string DomicileDisttName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        public int EnterByUser_ID { get; set; }
        public int ModifyByUser_ID { get; set; }
        public DateTime ModifyDate { get; set; }

        public int jobid { get; set; }
        public string jobname { get; set; }
    }
}
