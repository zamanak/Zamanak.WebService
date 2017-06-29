using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Request
{
    public class Campaign_NewCampaignByNumbersRequest
    {
        public string Name { get; set; }

        public List<string> Numbers { get; set; }

        public long RecordingId { get; set; }

        public string StartTime { get; set; }

        public string StopTime { get; set; }

        public string RepeatTotal { get; set; }

        public Campaign_NewCampaignByNumbersRequest(string name, List<string> numbers, long recordingId, string startTime, string stopTime, string repeatTotal)
        {
            Name = name;
            Numbers = numbers;
            RecordingId = recordingId;
            StartTime = startTime;
            StopTime = stopTime;
            RepeatTotal = repeatTotal;
        }

        public Campaign_NewCampaignByNumbersRequest()
        {

        }
    }
}
