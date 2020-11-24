using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BusinessLayer2.CustomModels
{
    public class bcDownload
    {
       
        public int DownloadID { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }
       
        public string DownloadPath { get; set; }

        public HttpPostedFileBase DownloadFile { get; set; }

        public int uid { get; set; }

        public DateTime EntryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
