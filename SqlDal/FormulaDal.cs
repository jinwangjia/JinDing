using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SqlDal
{
    /// <summary>
    /// 配方
    /// </summary>
    public class FormulaDal:ParentDal<FormulaDefinition>
    {
        public class QueryByParam1In
        {
            //public DateTime BeginDateTime { get; set; }
            //public DateTime EndDateTime { get; set; }
            //分页
            public int Page { get; set; }
            //每页行数
            public int Rows { get; set; }
            //总行数(这是一个返回值)
            public int Total { get; set; }
        }


        public IList<FormulaDefinition> QueryByParam1(QueryByParam1In param)
        {
            //param.BeginDateTime = param.BeginDateTime.Date;
            //param.EndDateTime = param.EndDateTime.AddDays(1);
            using (var dal = new BaseDal())
            {
                var list = from o in dal.Formula where (true) select o;
                param.Total = list.Count();
                list = from o in list orderby o.UpdateDateTime select o;
                list = list.Skip((param.Page - 1) * param.Rows).Take(param.Rows);
                return (list).ToList();
            }
        }

    }
}
