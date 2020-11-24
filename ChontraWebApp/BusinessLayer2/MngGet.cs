using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer2.CustomModels;

namespace BusinessLayer2
{
    public class MngGet
    {
        private dbSiteEntities objContext;
        public bcChiefMessage Get1ChairMessage(int id)
        {
            using (objContext = new dbSiteEntities())
            {
                return objContext.tblTexts.Where(t=> t.TextID.Equals(id)).Select(p=> new bcChiefMessage { MessageID = p.TextID, MessageTitle = p.TextTitle, MessageDetails = p.TextDetail, MessageActive = p.IsActive }).First();
            }
        }

        //public List<tblDesignation> GetDesignationsDD()
        //{
        //    using(objContext = new dbSiteEntities())
        //    {
        //        return objContext.tblDesignations.ToList();
        //    }
        //}

        //public bcCabinet GetMemberDetails(int mid)
        //{
        //    using(objContext = new dbSiteEntities())
        //    {
        //      return  objContext.tblTeamMembers.Where(m=> m.SocMemID.Equals(mid)).Select(t => new bcCabinet { CabinetID = t.SocMemID, CabinetName = t.MemberName, Qualification = t.Qualification, EduDetails = t.EducationDetails, JobDetails = t.JobDetails, Email = t.MemberEmail, Contactno = t.MemberContactNo, Address = t.MemberAddress, IsActive = t.IsActive, ImagePath = t.ImagePath }).FirstOrDefault();
        //    }
        //}
    }
}
