using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request.General
{
    public class SendCaptchaSmsRequest
    {
        public string Mobile { get; set; }

        public long Captcha { get; set; }
    }
}
