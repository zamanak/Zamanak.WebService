using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request
{
    public class CampaignReport_GetCampaignStatusRequest
    {
        public string CampId { get; set; }

        public CampaignReport_GetCampaignStatusRequest(string campId)
        {
            CampId = campId;
        }

        public CampaignReport_GetCampaignStatusRequest()
        {

        }
    }
}
