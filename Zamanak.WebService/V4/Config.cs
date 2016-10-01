using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService
{
    public class Config
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string UID { get; set; }

        public string Token { get; set; }

        /// <summary>
        /// For example http://www.zamanak.ir
        /// </summary>
        public string ServerBaseUrl { get; set; }

        public string ApiPath { get; set; } = "api/json-v4";
    }
}
