using Common;
using hgd.Enity;
using hgd.webapi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace hgd.webapi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] User user)
        {
            if (user != null)
            {
                //如果是张三
                if (user.Name.ToString() == "张三")
                {
                   
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("userId", "1");
                    dic.Add("userName", "zhangsan");
                    dic.Add("roles", "admin");
                    var token = new JWTHelper().Encode(dic,"abcdefg", 30);//dic:个人信息 abcdefg：key 30：过期时间
                    return Json(new MessageModel() { code = (int)HttpCode.OK, msg = "OK", data = token });
                }
                else
                {
                    return Json(new MessageModel() { code = (int)HttpCode.AuthenticationRequired, msg = "登录失败" });
                }

            }
            else
            {
                return Json(new MessageModel() { code = (int)HttpCode.NULL_PARAM, msg = "参数为空" });
            }


        }

        [Route("getuser")]
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            var user = (ClaimsPrincipal)User;
            var dic = new Dictionary<string, object>();
            foreach (var userClaim in user.Claims)
            {
                dic.Add(userClaim.Type, userClaim.Value);
            }
            return Json(new MessageModel() { code = (int)HttpCode.OK, msg = "OK", data = dic });
        }
        /// <summary>
        /// 只有某种角色的用户才有权限访问
        /// </summary>
        /// <returns></returns>
        [Route("onlyadmin"), HttpGet]
        [Authorize(Roles="admin")]
        public IHttpActionResult OnlyAdmin()
        {
            return Ok("仅管理员能访问的请求");
        }
        /// <summary>
        /// 只有某个用户才有权限访问
        /// </summary>
        /// <returns></returns>
        [Route("onlyuser"), HttpGet]
        [Authorize(Users =("lisi"))]
        public IHttpActionResult OnlyUser()
        {
            return Ok("仅张三能访问的请求");
        }

        [Route("custom"), HttpGet]
        [RoleAuthorize(Roles  = ("admin,user"))]
        public IHttpActionResult CustomRole()
        {
            return Ok("ok");
        }
    }
}
