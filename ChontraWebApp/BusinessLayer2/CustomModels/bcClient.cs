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
    public class bcClient
    {
        [DisplayName("Id")]
        public int ClientID { get; set; }

        [DisplayName("Name")]
        public string ClientName { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Logo")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public int uid { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
