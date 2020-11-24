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
    public class bcSlider
    {
        public int SliderID { get; set; }
 
        [DisplayName("Caption: ")] 
        public string Cap1 { get; set; }
        public string Cap2 { get; set; }
        public string Cap3 { get; set; }      
        public bool IsActive { get; set; }

        //[Required(ErrorMessage = "Image Error in Model")]
        [DisplayName("Upload Image:")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public int uid { get; set; }
        
    }
}
