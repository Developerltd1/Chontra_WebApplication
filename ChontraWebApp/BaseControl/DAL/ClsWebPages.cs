using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.DAL
{
    public class ClsWebPages
    {
        public int WebPageID { get; set; }
        public int Parent_ID { get; set; }
        public int PageOrder { get; set; }
        public bool IsVisible { get; set; }
        public string PageTitle { get; set; }
        public string PageIcon { get; set; }
        public string ControllerName { get; set; }
        public string ViewName { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }
        public List<string> Urls { get; set; }
        public bool HasDelete { get; set; }
        public bool HasUpdate { get; set; }
        public bool HasInsert { get; set; }
        public string MenuTitle { get; set; }
        public bool IsHorizantal { get; set; }
        public string MenuColor { get; set; }
        public long Count { get; set; }
        public bool? IsChecked { get; set; }

        public List<ClsWebPages> Childs { get; set; }
    }
}
