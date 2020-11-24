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
    public class bcTestimonial
    {
        public int TestiID { get; set; }

        [DisplayName("Name: ")]
        public string Name { get; set; }

        [DisplayName("Detail: ")]
        public string Detail { get; set; }

        //[Required(ErrorMessage = "Image Error in Model")]
        [DisplayName("Upload Image:")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("Organization/Designation:")]
        public string Desg { get; set; }

        public double Rating { get; set; }
        public bool IsActive { get; set; }

        public int uid { get; set; }
    }
}
