using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.DAL
{
    public class ClsDALRoles
    {
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
        public int CreatedBy { get; set; }
        public int Organization_ID { get; set; }

        public List<ClsRoleWebPages> RoleWebPages { get; set; }
    }

    public class ClsRoleWebPages
    {
        public int WebPageID { get; set; }
        public int Parent_ID { get; set; }
        public string PageTitle { get; set; }
        public bool IsChecked { get; set; }
        public bool HasDelete { get; set; }
        public bool HasUpdate { get; set; }
        public bool HasInsert { get; set; }
        public List<ClsRoleWebPages> Childs { get; set; }
        public string PageIcon { get; set; }
    }
}
