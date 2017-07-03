using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Response
{
    public class General_TextToVoiceCalculatorResponse
    {
        /// <summary>
        /// length of converted wav file in seconds
        /// </summary>
        public long LengthInSeconds { get; set; }
    }
}
