using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;

namespace SqlDal
{
    public class ZkGetOrderDal:ParentDal<ZkGetOrderDefinition>
    {
        public class QueryByParamIn
        {
            //分页
            public int Page { get; set; }
            //每页行数
            public int Rows { get; set; }
            //总行数(这是一个返回值)
            public int Total { get; set; }
        }

        public IList<ZkGetOrderDefinition> QueryByParam(QueryByParamIn param)
        {
            using (var dal = new BaseDal())
            {
                var list = from o in dal.ZkGetOrder where (true) select o;
                param.Total = list.Count();
                list = from o in list orderby o.ManufacturingDate select o;
                list = list.Skip((param.Page - 1) * param.Rows).Take(param.Rows);
                return (list).ToList();
            }
        }
    }
}
