using Common;
using hgd.Enity;
using hgd.IRepository;
using hgd.Repository;
using hgd.webapi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace hgd.webapi.Controllers
{
    [RoutePrefix("api/sql")]
    public class SqlSugarController : ApiController
    {
        private IUserRepository _user;
        public SqlSugarController(UserRepository userRepository)
        {
            _user = userRepository;
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add([FromBody]User user)
        {
            if (user == null)
                return Json(new MessageModel() { code = (int)HttpCode.NULL_PARAM, msg = "参数为空" });
            return Json(_user.Add(user));
        }
        [HttpPost]
        [Route("del")]
        public IHttpActionResult Dels ([FromBody]dynamic[] ids)
        {
            if (ids.Length == 0)
                return Json(new MessageModel() { code = (int)HttpCode.NULL_PARAM, msg = "参数为空" });
            return Json(_user.Dels(ids));
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update([FromBody]User user)
        {
            if (user == null)
                return Json(new MessageModel() { code = (int)HttpCode.NULL_PARAM, msg = "参数为空" });
            return Json(_user.Update(user));
        }
        [HttpGet]
        [Route("getuser")]
        public IHttpActionResult Getuser(int pageIndex = 1, int pageSize = 10)
        {
            return Json(_user.GetPageList(pageIndex, pageSize));
        }
    }
}
