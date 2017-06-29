using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Response
{
    public class General_NumberReaderResponse
    {
        public long Result { get; set; }

        public string Message { get; set; }

        public string CaptchaCode { get; set; }
    }
}
