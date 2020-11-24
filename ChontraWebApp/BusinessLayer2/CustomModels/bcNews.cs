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
    public class bcNews
    {
        public int NewsID { get; set; }

        [DisplayName("Title: ")] 
        public string NewsTitle { get; set; }

        [DisplayName("Details: ")] 
        public string NewsDetails { get; set; }

        public byte TextType = 21;  // not in use here
        public int uid { get; set; }

        [DisplayName("Upload Image: ")] 
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
