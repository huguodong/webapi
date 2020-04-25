using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Page
    {
        /// <summary>
        /// 是否第一页
        /// </summary>
        public bool is_first_page;
        /// <summary>
        /// 是否最后一页
        /// </summary>
        public bool is_last_page;
        /// <summary>
        /// 第几页
        /// </summary>
        public int page_no;
        /// <summary>
        /// 每页多少条
        /// </summary>
        public int page_size;
        /// <summary>
        /// 总量
        /// </summary>
        public int total_count;
        /// <summary>
        /// 总页数
        /// </summary>
        public int total_page;
    }
}
