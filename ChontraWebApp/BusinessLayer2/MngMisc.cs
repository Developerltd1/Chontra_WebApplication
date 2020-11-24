using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2
{
    public static class MngMisc
    {

        public static bool check_file_ext(string ext)
        {
            if (ext.Equals(".doc") || ext.Equals(".docx") || ext.Equals(".pdf"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool check_image_ext(string ext)
        {
            if (ext.Equals(".jpg") || ext.Equals(".png") || ext.Equals(".jpeg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
