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
    public class bcGallery
    {
        public int GalleryID { get; set; }

        [DisplayName("Title: ")]
        public string Title { get; set; }

        [DisplayName("Detail: ")]
        public string Detail { get; set; }

        [DisplayName("Type: ")]
        public string Type { get; set; } 

        //[Required(ErrorMessage = "Image Error in Model")]
        [DisplayName("Upload Image:")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public bool IsActive { get; set; }

        public int uid { get; set; }

    }
}
