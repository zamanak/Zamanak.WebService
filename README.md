# Zamanak .NET Web service client

In order to use zamanak api, you should have username and password so feel free go to zamanak.ir and register.
some zamanak apis need `uid and token` to work properly so you need to first call `general/authenticate` method to receive uid and token, 
remember that token is valid for one year.

+ [Create a Zamanak Client Object](#create-a-zamanak-client-object)
+ [Sending auto generated random numeric captcha](#sending-auto-generated-random-numeric-captcha)
+ [Sending a number to specified mobile, number will be read for person](#sending-a-number-to-specified-mobile)
+ [Create new campaign by text](#create-new-campaign-by-text)
+ [Create new campaign by numbers](#create-new-campaign-by-numbers)
+ [Create new mix campaign](#create-new-mix-campaign)
+ [Get campaign status](#get-campaign-status)
+ [Get campaign logs](#get-campaign-logs)


## Create a Zamanak Client Object
```c#
using Zamanak.WebService.V5;
using Zamanak.WebService.V5.Request;
using Zamanak.WebService.V5.Response;
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
**Note: number will be read for person**

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

var req = new Campaign_NewCampaignByTextRequest("CAMPAIGN NAME", numbers, "TEXT", "START_TIME", "STOP_TIME", "REPEAT_TOTAL");
var res = client.Campaign.NewCampaignByText(req);
```

### Create new campaign by numbers
**Note: Empty startTime means now . repeat number shoud be greater than zero : >=1**

```c#
var numbers = new List<string>();
numbers.Add("0912*******");
numbers.Add("0912*******");
long recordingId = 0; //recordingId of uploaded sound

var req = new Campaign_NewCampaignByNumbersRequest("CAMPAIGN NAME", numbers, recordingId, "START_TIME", "STOP_TIME", "REPEAT_TOTAL");
var res = client.Campaign.NewCampaignByNumbers(req);
```

### Create new mix campaign
**Note: This method create new mix campaign,machine first reading your recording audio then read number,$recording array contain your recording id,$numbers contain your numbers which you want to say,notice that each element of array is for one contact so sepreate numbers of each element by ','.$sayMethod means that how do you like to say your numbers?for example if your number is 3139687 and sayMethod is 322 means machine reads 313 96 87,$mixType is default 'number'**

```c#
var campaignName = "test campaign name";
long contact_count = 2;
long recording_count = 2;
long numbers_count = 2;

var to = new List<string>();
to.Add("0912*******");
to.Add("0912*******");

var recordings = new List<string>();
recordings.Add("12345");
recordings.Add("12346");

var numbers = new List<string>();
numbers.Add("123456,1234567");
numbers.Add("1234567,1234578");

string sayMethod = "322";
string mixType = "number";
long retry = 1; //retry count

var req = new Campaign_NewMixCampaignRequest(campaignName, contact_count, recording_count, numbers_count, to, recordings, numbers, sayMethod, mixType, retry);
var res = client.Campaign.NewMixCampaign(req);
Console.WriteLine("CampId=" + res.CampId);
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