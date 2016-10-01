using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request.General
{
    public class NumberReaderRequest
    {
        public string Mobile { get; set; }

        public string NumberToSay { get; set; }

        public NumberReaderRequest(string mobile, string numberToSay)
        {
            Mobile = mobile;
            NumberToSay = numberToSay;
        }

        public NumberReaderRequest()
        {

        }
    }
}
