using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Response
{
    public class CampaingReport_LiveNumberStatusResponse
    {
        public string PhoneNumber { get; set; }
        public string StartStamp { get; set; }
        public string CampId { get; set; }
        public string Status { get; set; }
        public string Digit { get; set; }
    }
}
