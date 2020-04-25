using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace hgd.webapi.Expections
{
    public class CustomErrorMessageDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(ResponseMessage);
        }
        public HttpResponseMessage ResponseMessage(Task<HttpResponseMessage> request)
        {
            HttpResponseMessage response = request.Result;
            HttpError error = null;

            if (response.TryGetContentValue<HttpError>(out error))
            {
                //添加自定义错误处理
                //error.Message = "Your Customized Error Message";
            }
            if (error != null)
            {
                ////获取抛出自定义异常，有拦截器统一解析
                return Utils.toJson(response.StatusCode, new { code = response.StatusCode, message = error.Message }); 
            }
            else
            {
                return response;
            }

        }
    }
}