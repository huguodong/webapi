using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hgd.webapi.Models
{
    public class Result
    {
        /// <summary>
        /// 码值
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HttpCode code;
        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string msg;
        /// <summary>
        /// 具体的数据
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object data;

        public Result()
        {

        }
        public Result(HttpCode code, string msg, object data)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }
    }
}