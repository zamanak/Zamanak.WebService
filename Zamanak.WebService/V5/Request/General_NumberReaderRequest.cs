using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Request
{
    public class General_NumberReaderRequest
    {
        public string Mobile { get; set; }

        public string NumberToSay { get; set; }

        public General_NumberReaderRequest(string mobile, string numberToSay)
        {
            Mobile = mobile;
            NumberToSay = numberToSay;
        }

        public General_NumberReaderRequest()
        {

        }
    }
}
