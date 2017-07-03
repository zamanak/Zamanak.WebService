using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Request
{
    public class General_TextToVoiceCalculatorRequest
    {
        public string Text { get; set; }

        public General_TextToVoiceCalculatorRequest(string text)
        {
            Text = text;
        }

        public General_TextToVoiceCalculatorRequest()
        {

        }
    }
}
