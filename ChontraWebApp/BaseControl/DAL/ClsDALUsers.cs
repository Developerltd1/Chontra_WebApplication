using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCode.DAL
{
    public class ClsDALUsers
    {
        public HttpPostedFileBase ImageUpload { get; set; }
        public int UserID { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string OrganizationName { get; set; }
        public int Organization_ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int Role_ID { get; set; }
        public string RoleName { get; set; }
        public int Campus_ID { get { return 1; } }
    }
}
