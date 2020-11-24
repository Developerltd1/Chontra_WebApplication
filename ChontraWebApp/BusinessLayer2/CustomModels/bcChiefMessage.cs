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
    public class bcChiefMessage
    {
        public int MessageID { get; set; }

        [DisplayName("Title")]  
        public string MessageTitle { get; set; }

        [DisplayName("Details")]  
        public string MessageDetails { get; set; }
   
        public bool MessageActive { get; set; }

        [DisplayName("Upload Image")]  
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public byte TextType = 1;
        public int uid { get; set; }
    }
}
