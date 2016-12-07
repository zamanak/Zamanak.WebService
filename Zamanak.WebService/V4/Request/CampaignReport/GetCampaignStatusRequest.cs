using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Request.CampaignReport
{
    public class GetCampaignStatusRequest
    {
        public string CampId { get; set; }

        public GetCampaignStatusRequest(string campId)
        {
            CampId = campId;
        }

        public GetCampaignStatusRequest()
        {

        }
    }
}
