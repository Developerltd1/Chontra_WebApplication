using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2
{
    public class MngAbout
    {
        public string GetAboutMessageforAboutPage()
        {

            using (dbSiteEntities objContext = new dbSiteEntities())
            {
                tblText obj = new tblText();
                //string obj = objContext.tblTexts.OrderByDescending(t => t.TextType_ID.Equals(1)).First().TextDetail;
                return objContext.tblTexts.Where(t => t.TextType_ID == 10).OrderByDescending(t => t.TextID).First().TextDetail;
                // return obj.TextDetail;

            }
        }   
    }
}
