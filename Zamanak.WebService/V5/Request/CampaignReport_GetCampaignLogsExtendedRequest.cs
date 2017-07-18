using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Request
{
    public class CampaignReport_GetCampaignLogsExtendedRequest
    {
        public string CampId { get; set; }

        public string Page { get; set; }

        public CampaignReport_GetCampaignLogsExtendedRequest(string campId, string page)
        {
            CampId = campId;
            Page = page;
        }

        public CampaignReport_GetCampaignLogsExtendedRequest()
        {

        }
    }
}
