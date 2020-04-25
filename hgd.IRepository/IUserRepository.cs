using Common;
using hgd.Enity;
using hgd.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hgd.IRepository
{
    public interface IUserRepository
    {

        User GetById(long id);


        MessageModel GetPageList(int pageIndex, int pageSize);

        MessageModel Add(User entity);


        MessageModel Update(User entity);


        MessageModel Dels(dynamic[] ids);

    }
}
