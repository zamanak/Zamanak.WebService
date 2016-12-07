using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request
{
    public class General_CaptchaRequest
    {
        public string Mobile { get; set; }

        public General_CaptchaRequest(string mobile)
        {
            Mobile = mobile;
        }

        public General_CaptchaRequest()
        {

        }
    }
}
