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
    
    public partial class Membership_Users
    {
        public int UserID { get; set; }
        public Nullable<int> Role_ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
