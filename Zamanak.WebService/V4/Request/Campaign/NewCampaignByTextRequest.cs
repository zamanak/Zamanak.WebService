using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request.Campaign
{
    public class NewCampaignByTextRequest
    {
        public string Name { get; set; }

        public List<string> Numbers { get; set; }

        public string Text { get; set; }

        public string StartTime { get; set; }

        public string StopTime { get; set; }

        public string RepeatTotal { get; set; }

        public NewCampaignByTextRequest(string name, List<string> numbers, string text, string startTime, string stopTime, string repeatTotal)
        {
            Name = name;
            Numbers = numbers;
            Text = text;
            StartTime = startTime;
            StopTime = stopTime;
            RepeatTotal = repeatTotal;
        }

        public NewCampaignByTextRequest()
        {

        }
    }
}
