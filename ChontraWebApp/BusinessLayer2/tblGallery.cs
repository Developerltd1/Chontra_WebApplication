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
    
    public partial class tblGallery
    {
        public int GalleryID { get; set; }
        public string GalleryImage { get; set; }
        public string GalleryTitle { get; set; }
        public string GalleryDescription { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public int EnterBy_ID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Year { get; set; }
        public string Alt { get; set; }
    }
}