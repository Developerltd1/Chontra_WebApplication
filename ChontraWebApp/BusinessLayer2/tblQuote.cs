//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer2
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblQuote
    {
        public int QuoteID { get; set; }
        public string FromLoc { get; set; }
        public string ToLoc { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public System.DateTime EntryDate { get; set; }
        public bool isActive { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string MobileNo { get; set; }
        public string QuoteType { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
        public Nullable<int> IsRecieved { get; set; }
    }
}