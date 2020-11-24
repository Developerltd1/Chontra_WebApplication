using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer2.CustomModels
{
    public class bcAboutMessage
    {
        public int MessageID { get; set; }

        [DisplayName("Title")]
        public string MessageTitle { get; set; }

        [DisplayName("Details")]
        public string MessageDetails { get; set; }

        public bool MessageActive { get; set; }

        public byte TextType = 10;

        public int uid { get; set; }
    }
}
