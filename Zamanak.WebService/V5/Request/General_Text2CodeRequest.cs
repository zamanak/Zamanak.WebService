using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Request
{
    public class General_Text2CodeRequest
    {
        public string Text { get; set; }

        public General_Text2CodeRequest(string text)
        {
            Text = text;
        }

        public General_Text2CodeRequest()
        {

        }
    }
}
