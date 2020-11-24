using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.CustomModels
{
    public class bcActivityy
    {
        [DisplayName("ID")]  
        public int ActivityID { get; set; }
        [DisplayName("Title")] 
        public string ActivityTitle { get; set; }
        [DisplayName("Date")]
        public DateTime ActivityDate { get; set; }
        [DisplayName("Time")] 
        public string ActivityTime { get; set; }
        [DisplayName("Entry Date")] 
        public DateTime ActivityEntryDate { get; set; }
        [DisplayName("Place")] 
        public string ActivityPlace { get; set; }
        [DisplayName("Details")] 
        public string ActivityDetails { get; set; }
        [DisplayName("Confrence_ID")] 
        public int Confrence_ID { get; set; }
        [DisplayName("EnterBy_ID")] 
        public int ActivityEnterBy_ID { get; set; }
        [DisplayName("ActivityDay")] 
        public int ActivityDay { get; set; }

        public int uid { get; set; }

    }
}
