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
    public class bcFood
    {
        public int FoodID { get; set; }

        [DisplayName("Title: ")]
        public string Title { get; set; }

        [DisplayName("Detail: ")]
        public string Detail { get; set; }

        public char Type = 'F';

        //[Required(ErrorMessage = "Image Error in Model")]
        [DisplayName("Upload Image:")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public bool IsActive { get; set; }

        public int uid { get; set; }
    }
}
