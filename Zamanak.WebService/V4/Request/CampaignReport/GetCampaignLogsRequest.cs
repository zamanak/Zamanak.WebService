using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request.CampaignReport
{
    public class GetCampaignLogsRequest
    {
        public string CampId { get; set; }

        public string Page { get; set; }

        public GetCampaignLogsRequest(string campId, string page)
        {
            CampId = campId;
            Page = page;
        }

        public GetCampaignLogsRequest()
        {

        }
    }
}
