using Common;
using hgd.Enity;
using hgd.IRepository;
using hgd.IService;
using hgd.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hgd.Repository
{
    public class UserRepository : IUserRepository
    {
        public IUserService _IUser;
        public UserRepository(UserService userService)
        {
            _IUser = userService;
        }

        public MessageModel Add(User entity)
        {
            if (_IUser.Add(entity))
                return new MessageModel { code = (int)HttpCode.OK, msg = "操作成功" };
            else
                return new MessageModel { code = (int)HttpCode.FAILED, msg = "操作失败" };
        }

        public MessageModel Dels(dynamic[] ids)
        {
            if (_IUser.Dels(ids))
                return new MessageModel { code = (int)HttpCode.OK, msg = "操作成功" };
            else
                return new MessageModel { code = (int)HttpCode.FAILED, msg = "操作失败" };
        }

        public User GetById(long id)
        {
            return _IUser.Get(id);
        }


        public MessageModel Update(User entity)
        {
            if (_IUser.Update(entity))
                return new MessageModel { code = (int)HttpCode.OK, msg = "操作成功" };
            else
                return new MessageModel { code = (int)HttpCode.FAILED, msg = "操作失败" };
        }

        MessageModel IUserRepository.GetPageList(int pageIndex, int pageSize)
        {
            var data = _IUser.GetPageList(pageIndex, pageSize);
            MessageModel user = new MessageModel();
            user.code = (int)HttpCode.OK;
            user.msg = "ok";
            user.page = user.page;
            user.data = data.data;
            return user;

        }
    }
}
