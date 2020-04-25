
using Common;
using hgd.webapi.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;


namespace hgd.webapi.Expections
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
       
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;//获取产生的异常对象
            var exceptionMessage = exception.Message;
            var logMessage =
                $@"controller.action={actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName}.{actionExecutedContext.ActionContext.ActionDescriptor.ActionName}:exception="
                + exception.Message;//异常内容
            ILog log = LogManager.GetLogger(actionExecutedContext.ActionContext.ControllerContext.Controller.GetType());
            Result result = new Result();
            if (exception is KnownException)//如果是已知异常
            {
                log.Debug(logMessage);
                var ex = (KnownException)actionExecutedContext.Exception;
                result.code = ex.code;
                result.msg = ex.msg;
            }
            else//如果是未知异常
            {
                log.Error(logMessage, exception);
                result.code = HttpCode.ERROR;
                result.msg = "内部错误";
                result.data = exceptionMessage;
            }
            actionExecutedContext.ActionContext.Response = Utils.toJson(HttpStatusCode.BadRequest, result);

        }
    }
}