using Autofac.Integration.WebApi;
using hgd.webapi.AutoFac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace hgd.webapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // 获取webapi的配置
            var config = GlobalConfiguration.Configuration;
            // 获取webapi的依赖注入容器
            var container = ContainerBuilerCommon.GetWebApiContainer();
            // 配置webapi的依赖注入
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
