using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request.General
{
    public class CaptchaRequest
    {
        public string Mobile { get; set; }

        public CaptchaRequest(string mobile)
        {
            Mobile = mobile;
        }

        public CaptchaRequest()
        {

        }
    }
}
