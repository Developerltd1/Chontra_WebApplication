using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2
{
    public class MngEvent
    {
        public List<tblEvent> GetEventsListforEventPage()
        {
            using (dbSiteEntities objContext = new dbSiteEntities())
            {
                //tblEe obj = new tblText();
                //string obj = objContext.tblTexts.OrderByDescending(t => t.TextType_ID.Equals(1)).First().TextDetail;
                return objContext.tblEvents.ToList();

            }
        }
    }
}
