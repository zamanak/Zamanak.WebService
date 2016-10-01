using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService.V4
{
    public class Config
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string UID { get; set; }

        public string Token { get; set; }

        public string ServerBaseUrl { get; set; }

        public string ApiPath { get; set; }

        public Config(string userName, string password, string uid, string token, string serverBaseUrl = "http://www.zamanak.ir", string apiPath = "api/json-v4")
        {
            UserName = userName;
            Password = password;
            UID = uid;
            Token = token;
            ServerBaseUrl = serverBaseUrl;
            ApiPath = apiPath;
        }

        public Config()
        {

        }
    }
}
