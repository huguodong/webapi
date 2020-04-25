using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace hgd.webapi.Expections
{
    public class KnownException : Exception
    {
        public HttpCode code;
        public string msg;

        public KnownException(HttpCode code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }
    }
}