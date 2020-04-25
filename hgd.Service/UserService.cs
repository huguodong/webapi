using Common;
using Common.DB;
using hgd.Enity;
using hgd.IService;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hgd.Service
{
    public class UserService : DbContext<User>, IUserService
    {
        private ILog _log;
        public UserService(ILog log)
        {
            _log = log;
            //打印sql
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                _log.Debug(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };
        }
        public bool Add(User entity)
        {
            return SimpleDb.Insert(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return SimpleDb.DeleteByIds(ids);
        }

        public User Get(long id)
        {
            return SimpleDb.GetById(id);
        }

        public TableModel<User> GetPageList(int pageIndex, int pageSize)
        {
            int totalNumber = 0;
            int totalPage = 0;
            List<User> data = SimpleDb.AsQueryable().Where(t => t.Age == 12).ToPageList(pageIndex, pageSize, ref totalNumber, ref totalPage);
            Page page = Utils.GetPage(pageIndex, pageSize, totalNumber, totalPage);
            return new TableModel<User>() { count = data.Count, page = page, data = data };
        }

        public bool Update(User entity)
        {
            return SimpleDb.Update(entity);
        }
    }
}
