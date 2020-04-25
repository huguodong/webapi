using Autofac;
using Autofac.Integration.WebApi;
using Common;
using hgd.webapi.AutoFac.Module;
using hgd.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace hgd.webapi.AutoFac
{
    /// <summary>
    /// Autofac注册类
    /// </summary>
    public static class ContainerBuilerCommon
    {
        /// <summary>
        /// 注册方法
        /// </summary>
        /// <returns></returns>
        public static IContainer GetWebApiContainer()
        {
            var builder = new ContainerBuilder();
            // 注册webapi的所有控制器
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // 注册一个用于测试的组件。
            builder.RegisterType<Person>();
        
            builder.RegisterType<Page>().PropertiesAutowired();
            //注册日志组件
            builder.RegisterModule<LoggingModule>();
            //WebAPI只用引用services和repository的接口，不用引用实现的dll。
            //如需加载实现的程序集，将dll拷贝到bin目录下即可，不用引用dll
            var iService = Assembly.Load("hgd.IService");
            var service = Assembly.Load("hgd.Service");
            var IRepository = Assembly.Load("hgd.IRepository");
            var repository = Assembly.Load("hgd.Repository");
            //根据名称约定（服务层的接口和实现均以Services结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(iService, service)
              .Where(t => t.Name.EndsWith("Service")).AsSelf()
              .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(IRepository, repository)
 .Where(t => t.Name.EndsWith("Repository")).AsSelf().AsImplementedInterfaces();

            return builder.Build();
        }


    }
}