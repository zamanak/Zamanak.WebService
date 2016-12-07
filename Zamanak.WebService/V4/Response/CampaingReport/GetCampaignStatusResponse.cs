using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4.Response.CampaingReport
{
    public class GetCampaignStatusResponse
    {
        // {"id":"354130","type":"voice","name":"test","started_at":0,
        // "stop_at":0,"created":"2016-12-07 18:15","subject":"test","totalContacts":2,
        // "successfull":"1","unsuccessfull":1,"status":"16","recording_id":"50305"}
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
