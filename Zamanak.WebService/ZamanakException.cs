using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zamanak.WebService
{
    public class ZamanakException: Exception
    {
        public const int BAD_REQUEST = 400;

        public const int UNKNOWN_ERROR = 10000000;

        public const int DEFAULT_ERROR = 90000000;

        public int Code { get; set; }

        public ZamanakException(string message, int code = DEFAULT_ERROR) : base(message)
        {
            Code = code;
        }

        public ZamanakException(string message, Exception innerException, int code = DEFAULT_ERROR) : base(message, innerException)
        {
            Code = code;
        }
    }
}
