# Zamanak .NET Web service client

In order to use zamanak api, you should have username and password so feel free go to zamanak.ir and register.
some zamanak apis need `uid and token` to work properly so you need to first call `general/authenticate` method to receive uid and token, 
remember that token is valid for one year.

## Create a Zamanak Client Object
```c#
using Zamanak.WebService.V4;
using Zamanak.WebService.V4.Request.General;
using Zamanak.WebService.V4.Response.General;
...
// If you havn`t yet received YOUR_ZAMANAK_UID and YOUR_ZAMANAK_TOKEN leave them ""
Config config = new Config("YOUR_ZAMANAK_USERNAME", "YOUR_ZAMANAK_PASSWORD", "YOUR_ZAMANAK_UID", "YOUR_ZAMANAK_TOKEN");
ZamanakClient client = new ZamanakClient(config);
```

### Sending auto generated random numeric captcha
```c#
var req = new CaptchaRequest("0912*******");
var res =  client.General.Captcha(req);
```

### Sending a number to specified mobile, number will be read for person 

```c#
var req = new NumberReaderRequest("0912*******", "Your desire number to be read for user for example 1234");
var res = client.General.NumberReader(req);
```

### send your favorite number by sms.(maximum 8 characters)

```c#
var req = new SendCaptchaSmsRequest("0912*******", 1234);
var res = client.General.SendCaptchaSms(req);
```