using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TableModel<T>
    {
        /// <summary>
        /// 数量
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 分页信息
        /// </summary>
        public Page page { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> data { get; set; }
    }
}
