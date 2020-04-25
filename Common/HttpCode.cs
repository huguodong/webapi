using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum HttpCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS = 200,
        /// <summary>
        /// 失败
        /// </summary>
        ERROR = 500,

        /// <summary>
        /// 参数错误
        /// </summary>
        ERROR_PARAM = 600,
        /// <summary>
        /// 参数为空
        /// </summary>
        NULL_PARAM = 601,

        /// <summary>
        /// 数据库异常
        /// </summary>
        DB_ERROR = 600,

        /// <summary>
        /// 数据操作成功
        /// </summary>
        OK = 1,

        /// <summary>
        /// 数据操作失败
        /// </summary>
        FAILED = 0,

        /// <summary>
        /// 认证失败
        /// </summary>
        AuthenticationRequired=407


    }
}
