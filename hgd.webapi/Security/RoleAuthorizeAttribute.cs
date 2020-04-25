using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Security.Principal;
using Newtonsoft.Json;

namespace hgd.webapi.Security
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public string Roles { set; get; }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IPrincipal principal = actionContext.ControllerContext.RequestContext.Principal;
            //首先principal不能为空，且principal.Identity是已经通过身份验证的（即Identity.IsAuthenticated==true）
            //然后验证接口权限是否在角色里
            return (principal != null && principal.Identity != null
               && principal.Identity.IsAuthenticated&&Role_isValid(actionContext));
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = Utils.toJson(HttpStatusCode.OK, new { code = HttpStatusCode.Unauthorized, msg = "未授权" });
        }

        /// <summary>
        /// 验证用户角色
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected bool Role_isValid(HttpActionContext actionContext)
        {
            if (Roles!=null)
            {
                var authorization = actionContext.Request.Headers.Authorization;
                JWTHelper jwt = new JWTHelper();
                bool isValid = false;
                var userinfo = jwt.Decode(authorization.Scheme, Config.JWTKey, out isValid, out string errMsg);
                if (isValid)
                {
                    //token转json字符串再转数组
                    Dictionary<string, string> userDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(userinfo);
                    var user_roles = userDict["roles"].Split(',');
                    var need_roles= Roles.Split(',');
                    //判断角色是否在Roles里
                    foreach (var role in user_roles)
                    {
                        if (need_roles.Contains(role))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }
    }
}