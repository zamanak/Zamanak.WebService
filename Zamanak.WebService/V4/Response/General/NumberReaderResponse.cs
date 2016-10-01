using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Response.General
{
    public class NumberReaderResponse
    {
        public long Result { get; set; }

        public string Message { get; set; }

        public string CaptchaCode { get; set; }
    }
}
