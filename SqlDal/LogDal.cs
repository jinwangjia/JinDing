using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    /// <summary>
    /// 人员日志
    /// </summary>
    public class  LogDal:ParentDal<LogDefinition>
    {
        public class QueryByParam1In
        {
            public DateTime BeginDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
            //分页
            public int Page { get; set; }
            //每页行数
            public int Rows { get; set; }
            //总行数(这是一个返回值)
            public int Total { get; set; }
        }


        public IList<LogDefinition> QueryByParam1(QueryByParam1In param)
        {
            param.BeginDateTime = param.BeginDateTime.Date;
            param.EndDateTime = param.EndDateTime.AddDays(1);
            using (var dal = new BaseDal())
            {
                var list = from o in dal.Log where ((o.UpdateDateTime >= param.BeginDateTime) && (o.UpdateDateTime < param.EndDateTime))  select o;                
                param.Total = list.Count();
                list = from o in list orderby o.UpdateDateTime select o;
                list = list.Skip((param.Page - 1) * param.Rows).Take(param.Rows);
                return (list).ToList();
            }
        }

        public IList<LogDefinition> QueryNearN(int n)
        {
            using (var dal = new BaseDal())
            {
                return dal.Log.OrderByDescending(o => o.UpdateDateTime).Take(n).ToList();
            }
        }

    }
}
