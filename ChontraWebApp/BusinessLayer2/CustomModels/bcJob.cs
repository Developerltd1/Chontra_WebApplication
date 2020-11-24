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
    public class bcJob
    {
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public string Details { get; set; }

        
//[DataType(DataType.Date)]
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public string SPostDate {get;set;}
        public string SCloseDate { get; set; }
        public DateTime PostDate { get; set; }

//[DataType(DataType.Date)]
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CloseDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int EnterByUser_ID { get; set; }

        public DateTime ModifyDate { get; set; }
        public int MoifyByUser_ID { get; set; }

        [DisplayName("Upload Image:")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public bool IsActive { get; set; }
    }
}
