using hgd.webapi.Filter;
using hgd.webapi.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using hgd.webapi.Expections;
using Common;
using hgd.Repository;
using hgd.IRepository;

namespace hgd.webapi.Controllers
{
    /// <summary>
    /// 主控制器
    /// </summary>
    [RoutePrefix("api/index")]
    public class IndexController : ApiController
    {
        Person[] person = new Person[]
       {
            new Person { Id = 1, Name = "张三", Sex = "男", Age = 18 },
             new Person { Id = 1, Name = "李四", Sex = "女", Age = 18 },
              new Person { Id = 1, Name = "王二", Sex = "男", Age = 22 },
               new Person { Id = 1, Name = "麻子", Sex = "男", Age = 23 },

       };
        protected Person _person;
        private ILog _log;
        private IUserRepository _user;
        public IndexController(ILog log, Person person, UserRepository user)
        {
            _person = person;
            _log = log;
            _user = user;
        }
        /// <summary>
        /// index
        /// </summary>
        /// <returns></returns>
        [Route("index1")]
        [HttpGet]
        public IHttpActionResult index()
        {
            return Json(person);

        }

        /// <summary>
        /// index2
        /// </summary>
        /// <returns></returns>
        [Route("index2")]
        [HttpGet]
        public IHttpActionResult index2()
        {
            return NotFound();

        }
        /// <summary>
        /// 参数校验
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [ParamsFilter]
        [Route("params")]
        public IHttpActionResult Params([FromBody] Person person)
        {
            return Json(person);
        }

        /// <summary>
        /// 测试Autofac
        /// </summary>
        /// <returns></returns>
        [Route("autofac")]
        [HttpGet]
        public IHttpActionResult Autofac()
        {
            return Ok(_person.Say());

        }

        [Route("log4")]
        [HttpGet]
        public IHttpActionResult Log()
        {
            // 通过LogManager的静态方法GetLogger生成一个Ilog对象
            ILog log = LogManager.GetLogger(typeof(IndexController)); // 下面是日志处理
            log.Debug("测试debug", new Exception("debug异常"));
            log.Info("测试Info", new Exception("Info异常"));
            log.Warn("测试Warn", new Exception("Warn异常"));
            log.Error("测试Error", new Exception("Error异常"));
            log.Fatal("测试Fatal", new Exception("Fatal异常"));
            return Ok("已经写入日志");

        }

        [Route("autolog4")]
        [HttpGet]
        public IHttpActionResult AutoLog()
        {
            // 通过LogManager的静态方法GetLogger生成一个Ilog对象
            _log.Debug("测试debug", new Exception("debug异常"));
            _log.Info("测试Info", new Exception("Info异常"));
            _log.Warn("测试Warn", new Exception("Warn异常"));
            _log.Error("测试Error", new Exception("Error异常"));
            _log.Fatal("测试Fatal", new Exception("Fatal异常"));
            return Ok("已经写入日志");

        }
        [Route("know")]
        [HttpGet]
        public IHttpActionResult Know()
        {
            throw new KnownException(HttpCode.DB_ERROR, "数据库异常了");

        }
        [HttpGet]
        [Route("unknow")]
        public IHttpActionResult UnKnow()
        {
            throw new System.IO.IOException();
        }

        
    }
}
