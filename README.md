# Zamanak .NET Web service client

In order to use zamanak api, you should have username and password so feel free go to zamanak.ir and register.
some zamanak apis need `uid and token` to work properly so you need to first call `general/authenticate` method to receive uid and token, 
remember that token is valid for one year.

+ [Create a Zamanak Client Object](#create-a-zamanak-client-object)
+ [Sending auto generated random numeric captcha](#sending-auto-generated-random-numeric-captcha)
+ [Sending a number to specified mobile, number will be read for person](#sending-a-number-to-specified-mobile)
+ [Create new campaign by text](#create-new-campaign-by-text)
+ [Get campaign status](#get-campaign-status)
+ [Get campaign logs](#get-campaign-logs)


## Create a Zamanak Client Object
```c#
using Zamanak.WebService.V4;
using Zamanak.WebService.V4.Request;
using Zamanak.WebService.V4.Response;
...
// If you havn`t yet received YOUR_ZAMANAK_UID and YOUR_ZAMANAK_TOKEN leave them ""
Config config = new Config("YOUR_ZAMANAK_USERNAME", "YOUR_ZAMANAK_PASSWORD", "YOUR_ZAMANAK_UID", "YOUR_ZAMANAK_TOKEN");
ZamanakClient client = new ZamanakClient(config);
```

### Sending auto generated random numeric captcha
```c#
var req = new General_CaptchaRequest("0912*******");
var res =  client.General.Captcha(req);
```

### Sending a number to specified mobile
**Note: number will be read for person **

```c#
var req = new General_NumberReaderRequest("0912*******", "Your desire number to be read for user for example 1234");
var res = client.General.NumberReader(req);
```

### Send your favorite number by sms
**(maximum 8 characters)**

```c#
var req = new General_SendCaptchaSmsRequest("0912*******", 1234);
var res = client.General.SendCaptchaSms(req);
```

### Create new campaign by text
**Note: Empty startTime means now . repeat number shoud be greater than zero : >=1**

```c#
var numbers = new List<string>();
numbers.Add("0912*******");
numbers.Add("0912*******");

var req = new Campaign_NewCampaignByTextRequest("NAME", numbers, "TEXT", "START_TIME", "STOP_TIME", "REPEAT_TOTAL");
var res = client.Campaign.NewCampaignByText(req);
```

### Get campaign status

```c#
var req = new CampaignReport_GetCampaignStatusRequest("CAMP_ID");
var res = client.CampaignReport.GetCampaignStatus(req);
//process res
```

### Get campaign logs

```c#
var req = new CampaignReport_GetCampaignLogsRequest("CAMP_ID", "PAGE_NUMBER");
var res = client.CampaignReport.GetCampaignLogs(req);
//process res
```