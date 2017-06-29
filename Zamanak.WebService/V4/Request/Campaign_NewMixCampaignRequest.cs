using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request
{
    public class Campaign_NewMixCampaignRequest
    {
        public string Name { get; set; }

        public long ContactCount { get; set; }

        public long RecordingCount { get; set; }

        public long NumbersCount { get; set; }

        public List<string> To { get; set; }

        public List<string> Recordings { get; set; }

        public List<string> Numbers { get; set; }

        public string SayMethod { get; set; }

        public string MixType { get; set; }

        public long Retry { get; set; }

        public Campaign_NewMixCampaignRequest(string name, long contact_count, long recording_count, long numbers_count, List<string> to, List<string> recordings, List<string> numbers, string sayMethod, string mixType, long retry)
        {
            Name = name;
            ContactCount = contact_count;
            RecordingCount = recording_count;
            NumbersCount = numbers_count;
            To = to;
            Recordings = recordings;
            Numbers = numbers;
            SayMethod = sayMethod;
            MixType = mixType;
            Retry = retry;
        }

        public Campaign_NewMixCampaignRequest()
        {

        }
    }
}
