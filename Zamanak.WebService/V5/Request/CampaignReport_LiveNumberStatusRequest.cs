using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Request
{
    public class CampaignReport_LiveNumberStatusRequest
    {
        public string CampId { get; set; }

        public string Phone { get; set; }

        public CampaignReport_LiveNumberStatusRequest(string campId, string phone)
        {
            CampId = campId;
            Phone = phone;
        }

        public CampaignReport_LiveNumberStatusRequest()
        {

        }
    }
}
