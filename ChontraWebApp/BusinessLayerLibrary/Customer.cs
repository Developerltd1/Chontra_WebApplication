//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayerLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerConact { get; set; }
        public string CustomerCNIC { get; set; }
        public string CustomerAddress { get; set; }
        public int CreatedByUser_ID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public Nullable<int> ModifiedByUser_ID { get; set; }
        public Nullable<System.DateTime> ModifiedByDateTime { get; set; }
        public bool isActive { get; set; }
    }
}
