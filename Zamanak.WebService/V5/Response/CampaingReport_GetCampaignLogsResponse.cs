using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V5.Response
{
    public class CampaingReport_GetCampaignLogsResponse
    {
        public List<GetCampaignLogsItemResponse> Data { get; set; }
        public int Successfull { get; set; }
        public int Unsuccessfull { get; set; }
        public int Total { get; set; }
    }

    public class GetCampaignLogsItemResponse
    {
        public string CampaignLogId { get; set; }
        public string CampaignId { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Billsec { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Response { get; set; }
        public string CS { get; set; }
    }
}
