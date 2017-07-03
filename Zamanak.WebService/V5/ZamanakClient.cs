using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Zamanak.WebService.V5.Request;
using Zamanak.WebService.V5.Response;

namespace Zamanak.WebService.V5
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

            public Campaign_NewCampaignByNumbersResponse NewCampaignByNumbers(Campaign_NewCampaignByNumbersRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "newCampaignbyNumbers");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("name", req.Name);
                    JArray jNumbers = new JArray();
                    req.Numbers.ForEach(n => jNumbers.Add(n));
                    jObj.Add("numbers", jNumbers);
                    jObj.Add("recordingId", req.RecordingId);
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

                    var res = new Campaign_NewCampaignByNumbersResponse()
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

            public Campaign_NewMixCampaignResponse NewMixCampaign(Campaign_NewMixCampaignRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "newMixCampaign");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("name", req.Name);
                    jObj.Add("contact_count", req.ContactCount);
                    jObj.Add("recording_count", req.RecordingCount);
                    jObj.Add("numbers_count", req.NumbersCount);
                    JArray jTo = new JArray();
                    req.To.ForEach(n => jTo.Add(n));
                    jObj.Add("to", jTo);
                    JArray jRecordings = new JArray();
                    req.Recordings.ForEach(n => jRecordings.Add(n));
                    jObj.Add("recordings", jRecordings);
                    JArray jNumbers = new JArray();
                    req.Numbers.ForEach(n => jNumbers.Add(n));
                    jObj.Add("numbers", jNumbers);
                    jObj.Add("sayMethod", req.SayMethod);
                    jObj.Add("mixType", req.MixType);
                    jObj.Add("retry", req.Retry);

                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    Regex regex = new Regex(@"\d+");
                    Match match = regex.Match(response.Content);
                    if (match.Success)
                    {
                        var res = new Campaign_NewMixCampaignResponse()
                        {
                            CampId = response.Content
                        };
                        return res;
                    }

                    throw new ZamanakException(response.Content, ZamanakException.BAD_REQUEST);
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

            public CampaingReport_LiveNumberStatusResponse LiveNumberStatus(CampaignReport_LiveNumberStatusRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "liveNumberStatus");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("campid", req.CampId);
                    jObj.Add("phone", req.Phone);


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

                    var res = new CampaingReport_LiveNumberStatusResponse()
                    {
                        PhoneNumber = jResponse["phone_number"].ToString(),
                        StartStamp = jResponse["start_stamp"].ToString(),
                        CampId = jResponse["campaign_id"].ToString(),
                        Status = jResponse["status"].ToString(),
                        Digit = jResponse["digit"].ToString()
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

            public General_Text2CodeResponse Text2Code(General_Text2CodeRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "text2code");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("text", req.Text);

                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    General_Text2CodeResponse res = new General_Text2CodeResponse()
                    {
                        Content = response.Content
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    throw new ZamanakException("Some error in calling web service, see inner exception for detail.", ex);
                }
            }

            public General_TextToVoiceCalculatorResponse TextToVoiceCalculator(General_TextToVoiceCalculatorRequest req)
            {
                try
                {
                    JObject jObj = new JObject();
                    jObj.Add("method", "textToVoiceCalculator");
                    jObj.Add("clientId", "api@zamanak.ir");
                    jObj.Add("clientSecret", "9AmbEG61AgW3CQoSV1p3A4tS9CZ");
                    jObj.Add("uid", config.UID);
                    jObj.Add("token", config.Token);
                    jObj.Add("text", req.Text);

                    var request = new RestRequest(config.ApiPath, Method.POST);
                    request.AddQueryParameter("req", jObj.ToString());
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                    IRestResponse response = client.Execute(request);

                    if ((int)response.StatusCode == 105)
                        throw new ZamanakException("SYSTEM_ERROR", 105);

                    if ((int)response.StatusCode != 200)
                        throw new ZamanakException("UNKNOWN_ERROR", (int)response.StatusCode);

                    General_TextToVoiceCalculatorResponse res = new General_TextToVoiceCalculatorResponse()
                    {
                        LengthInSeconds = long.Parse(response.Content)
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
