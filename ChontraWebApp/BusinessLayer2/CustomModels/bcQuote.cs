using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer2.CustomModels
{
    public class bcQuote
    {
        public int Quoteid { get; set; }

        public string Name { get; set; }  // Person Name

        public string Organization { get; set; }  // Organization Name

        public string Details { get; set; }   // Details
        [DisplayName("Security Type:")]
        public string QuoteType { get; set; }  // Personal/Organization/Event 

        public string MobileNo { get; set; }

        public string Address { get; set; }

        [DisplayName("Landline:")]
        public string Contactno { get; set; }

        [DisplayName("Email:")]
        public string Email { get; set; }

        [DisplayName("From:")]
        public string FromLoc { get; set; }
        [DisplayName("To:")]
        public string ToLoc { get; set; }
        public DateTime EntryDate { get; set; }
        public bool isActive { get; set; }

        public int uid { get; set; }

        public int isReceived { get; set; }
    }
}
