using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer2.CustomModels
{
    public class bcHotel
    {
        public int HotelID { get; set; }

        [DisplayName("Hotel")]  
        public string HotelName { get; set; }

        [DisplayName("Address")] 
        public string Address { get; set; }

        [DisplayName("City")] 
        public string City { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Upload File")] 
        public string  ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public int uid { get; set; }

    }
}
