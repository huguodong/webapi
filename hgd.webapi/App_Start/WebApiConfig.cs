using FluentValidation.WebApi;
using hgd.webapi.Expections;
using hgd.webapi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace hgd.webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //默认输出JSON
            var formatters = config.Formatters.Where(formatter =>
                  formatter.SupportedMediaTypes.Where(media =>
                  media.MediaType.ToString() == "application/xml" || media.MediaType.ToString() == "text/html").Count() > 0) //找到请求头信息中的介质类型
                  .ToList();

            foreach (var match in formatters)
            {
                config.Formatters.Remove(match);  //移除请求头信息中的XML格式
            }

            FluentValidationModelValidatorProvider.Configure(config);
            config.MessageHandlers.Add(new CustomErrorMessageDelegatingHandler());
            config.Filters.Add(new WebApiExceptionFilterAttribute());
            config.Filters.Add(new IdentityBasicAuthentication());
        }
    }
}
