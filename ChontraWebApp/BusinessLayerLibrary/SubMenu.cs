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
    
    public partial class SubMenu
    {
        public int SubMenuID { get; set; }
        public string SubMenuTitle { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUser_ID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedByUser_ID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int PriceMenu_ID { get; set; }
    }
}