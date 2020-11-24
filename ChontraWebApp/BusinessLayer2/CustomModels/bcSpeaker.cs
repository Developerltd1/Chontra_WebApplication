using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BusinessLayer2.CustomModels
{
    public class bcSpeaker
    {

        public int SpeakerID { get; set; }

        [DisplayName("Name: ")] 
        public string SpeakerName { get; set; }

        [DisplayName("Personal: ")] 
        public string PersonDetails { get; set; }

        [DisplayName("Education: ")] 
        public string EduDetails { get; set; }

        [DisplayName("Professional: ")] 
        public string ProfDetails { get; set; }

        [DisplayName("Participation: ")] 
        public string ParticipationDetails { get; set; }

        [DisplayName("Topic: ")]
        public string Topic { get; set; }
     
        public bool IsActive { get; set; }

        //[Required(ErrorMessage = "Image Error in Model")]
        [DisplayName("Upload Image:")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public int uid { get; set; }



    }
}
