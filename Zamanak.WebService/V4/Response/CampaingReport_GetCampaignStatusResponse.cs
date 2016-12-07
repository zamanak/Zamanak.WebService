using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Response
{
    public class CampaingReport_GetCampaignStatusResponse
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string StartedAt { get; set; }
        public string StopAt { get; set; }
        public string Created { get; set; }
        public string Subject { get; set; }
        public int TotalContacts { get; set; }
        public int Successfull { get; set; }
        public int Unsuccessfull { get; set; }
        public string Status { get; set; }
        public string RecordingId { get; set; }
    }
}
