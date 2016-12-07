using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zamanak.WebService.V4.Request;
using Zamanak.WebService.V4.Response;

namespace Zamanak.WebService.V4
{
    public class ZamanakClient
    {
        private Config config;

        public GeneralResource General { get; }
        public CampaingResource Campaign { get; }
        public CampaingReportResource CampaingReport { get; }

        public ZamanakClient(Config config)
        {
            this.config = config;
            General = new GeneralResource(config);
            Campaign = new CampaingResource(config);
            CampaingReport = new CampaingReportResource(config);
        }

        public class CampaingResource
        {
            private Config config;
            private RestClient client;

            public CampaingResource(Config config)
            {
                this.config = config;
                this.client = new RestClient(config.ServerBaseUrl);
            }

            public Campaign_NewCampaignByTextResponse NewCampaignByText(Campaign_NewCampaignByTextRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "newCampaignbyText");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("name", req.Name);
                    JArray jNumbers = new JArray();
                    req.Numbers.ForEach(n => jNumbers.Add(n));
                    jObj.Add("numbers", jNumbers);
                    jObj.Add("text", req.Text);
                    jObj.Add("startTime", req.StartTime);
                    jObj.Add("stopTime", req.StopTime);
                    jObj.Add("repeatTotal", req.RepeatTotal);


                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    JObject jResponse = JObject.Parse(response.Content);

                    JToken error = jResponse.GetValue("error");
                    if (error != null)
                        throw new ZamanakException(error.ToString(), ZamanakException.BAD_REQUEST);

                    var res = new Campaign_NewCampaignByTextResponse()
                    {
                        CampId = jResponse["campId"].ToString()
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    throw new ZamanakException("Some error in calling web service, see inner exception for detail.", ex);
                }
            }
        }

        public class CampaingReportResource
        {
            private Config config;
            private RestClient client;

            public CampaingReportResource(Config config)
            {
                this.config = config;
                this.client = new RestClient(config.ServerBaseUrl);
            }

            public CampaingReport_GetCampaignStatusResponse GetCampaignStatus(CampaignReport_GetCampaignStatusRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "getCampaignStatus");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("campId", req.CampId);

                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    JObject jResponse = JObject.Parse(response.Content);

                    JToken error = jResponse.GetValue("error");
                    if (error != null)
                        throw new ZamanakException(error.ToString(), ZamanakException.BAD_REQUEST);

                    var res = new CampaingReport_GetCampaignStatusResponse()
                    {
                        Id = jResponse["id"].ToString(),
                        Type = jResponse["type"].ToString(),
                        Name = jResponse["name"].ToString(),
                        StartedAt = jResponse["started_at"].ToString(),
                        StopAt = jResponse["stop_at"].ToString(),
                        Created = jResponse["created"].ToString(),
                        Subject = jResponse["subject"].ToString(),
                        TotalContacts = int.Parse(jResponse["totalContacts"].ToString()),
                        Successfull = int.Parse(jResponse["successfull"].ToString()),
                        Unsuccessfull = int.Parse(jResponse["unsuccessfull"].ToString()),
                        Status = jResponse["status"].ToString(),
                        RecordingId = jResponse["recording_id"].ToString()
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    throw new ZamanakException("Some error in calling web service, see inner exception for detail.", ex);
                }
            }

            public CampaingReport_GetCampaignLogsResponse GetCampaignLogs(CampaignReport_GetCampaignLogsRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "getCampaignLogs");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("campId", req.CampId);
                    jObj.Add("page", req.Page);


                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 400)
                        throw new ZamanakException("INVALID_TAG_VALUE", 400);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    JObject jResponse = JObject.Parse(response.Content);

                    JToken error = jResponse.GetValue("error");
                    if (error != null)
                        throw new ZamanakException(error.ToString(), ZamanakException.BAD_REQUEST);

                    JArray jData = (JArray)jResponse["data"];
                    var data = new List<GetCampaignLogsItemResponse>();
                    for (int i = 0; i < jData.Count; i++)
                    {
                        data.Add(new GetCampaignLogsItemResponse()
                        {
                            CampaignLogId = jData[i]["campaignLogId"].ToString(),
                            CampaignId = jData[i]["campaignId"].ToString(),
                            PhoneNumber = jData[i]["phoneNumber"].ToString(),
                            Status = jData[i]["status"].ToString(),
                            Billsec = jData[i]["billsec"].ToString(),
                            ContactFirstName = jData[i]["contactFirstName"].ToString(),
                            ContactLastName = jData[i]["contactLastName"].ToString(),
                            Response = jData[i]["response"].ToString(),
                            CS = jData[i]["cs"].ToString()
                        });
                    }
                    var res = new CampaingReport_GetCampaignLogsResponse()
                    {
                        Data = data,
                        Successfull = int.Parse(jResponse["successfull"].ToString()),
                        Unsuccessfull = int.Parse(jResponse["unsuccessfull"].ToString()),
                        Total = int.Parse(jResponse["total"].ToString())
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    throw new ZamanakException("Some error in calling web service, see inner exception for detail.", ex);
                }
            }
        }

        public class GeneralResource
        {
            private Config config;
            private RestClient client;

            public GeneralResource(Config config)
            {
                this.config = config;
                this.client = new RestClient(config.ServerBaseUrl);
            }

            public General_CaptchaResponse Captcha(General_CaptchaRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "captcha");
                    jObj.Add("username", config.UserName);
                    jObj.Add("password", config.Password);
                    jObj.Add("mobile", req.Mobile);
                    jObj.Add("captcha", "");

                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode == 108)
                        throw new ZamanakException("INVALID_PHONE_NUMBER", 108);

                    if ((int)response.StatusCode == 111)
                        throw new ZamanakException("INVALID_CAPTCHA_CODE", 111);

                    if ((int)response.StatusCode == 113)
                        throw new ZamanakException("NO_BALANCE", 113);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    JObject jResponse = JObject.Parse(response.Content);

                    JToken error = jResponse.GetValue("error");
                    if (error != null)
                        throw new ZamanakException(error.ToString(), ZamanakException.BAD_REQUEST);

                    General_CaptchaResponse res = new General_CaptchaResponse()
                    {
                        Result = long.Parse(jResponse["result"].ToString()),
                        Message = jResponse["message"].ToString(),
                        CaptchaCode = jResponse["captcha_code"].ToString(),
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    throw new ZamanakException("Some error in calling web service, see inner exception for detail.", ex);
                }
            }

            public General_NumberReaderResponse NumberReader(General_NumberReaderRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "numberReader");
                    jObj.Add("username", config.UserName);
                    jObj.Add("password", config.Password);
                    jObj.Add("mobile", req.Mobile);
                    jObj.Add("numberToSay", req.NumberToSay);
                    jObj.Add("captcha", "");

                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode == 108)
                        throw new ZamanakException("INVALID_PHONE_NUMBER", 108);

                    if ((int)response.StatusCode == 111)
                        throw new ZamanakException("INVALID_CAPTCHA_CODE", 111);

                    if ((int)response.StatusCode == 113)
                        throw new ZamanakException("NO_BALANCE", 113);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    JObject jResponse = JObject.Parse(response.Content);

                    JToken error = jResponse.GetValue("error");
                    if (error != null)
                        throw new ZamanakException(error.ToString(), ZamanakException.BAD_REQUEST);

                    General_NumberReaderResponse res = new General_NumberReaderResponse()
                    {
                        Result = long.Parse(jResponse["result"].ToString()),
                        Message = jResponse["message"].ToString(),
                        CaptchaCode = jResponse["captcha_code"].ToString(),
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    throw new ZamanakException("Some error in calling web service, see inner exception for detail.", ex);
                }
            }

            public General_SendCaptchaSmsResponse SendCaptchaSms(General_SendCaptchaSmsRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "sendCaptchaSms");
                    jObj.Add("username", config.UserName);
                    jObj.Add("password", config.Password);
                    jObj.Add("mobile", req.Mobile);
                    jObj.Add("captcha", req.Captcha);

                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode == 108)
                        throw new ZamanakException("INVALID_PHONE_NUMBER", 108);

                    if ((int)response.StatusCode == 111)
                        throw new ZamanakException("INVALID_CAPTCHA_CODE", 111);

                    if ((int)response.StatusCode == 113)
                        throw new ZamanakException("NO_BALANCE", 113);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    JObject jResponse = JObject.Parse(response.Content);

                    JToken error = jResponse.GetValue("error");
                    if (error != null)
                        throw new ZamanakException(error.ToString(), ZamanakException.BAD_REQUEST);

                    General_SendCaptchaSmsResponse res = new General_SendCaptchaSmsResponse()
                    {
                        Message = jResponse["message"].ToString()
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    throw new ZamanakException("Some error in calling web service, see inner exception for detail.", ex);
                }
            }
        }
    }
}
