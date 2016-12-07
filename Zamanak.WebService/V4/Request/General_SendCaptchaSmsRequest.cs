using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request
{
    public class General_SendCaptchaSmsRequest
    {
        public string Mobile { get; set; }

        public long Captcha { get; set; }

        public General_SendCaptchaSmsRequest(string mobile, long captcha)
        {
            Mobile = mobile;
            Captcha = captcha;
        }

        public General_SendCaptchaSmsRequest()
        {

        }
    }
}
