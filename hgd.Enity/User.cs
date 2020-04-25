using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hgd.Enity
{
    [SugarTable("t_user")]
    public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
