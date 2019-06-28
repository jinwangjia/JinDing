using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    public class CommandDal:ParentDal<CommandDefinition>
    {
        public IList<CommandDefinition> QueryByFunctionId(string functionId)
        {
            using (var dal = new BaseDal())
            {
                return dal.Command.Where(o => o.FunctionId == functionId).OrderBy(o => o.Index).ToList();
            }
        }

        public void AndOrUpdate(CommandDefinition p)
        {
            using (var dal = new BaseDal())
            {
                var q = dal.Command.SingleOrDefault(o => (o.FunctionId == p.FunctionId) && (o.OnClick == p.OnClick));
                if (q == null)
                {
                    dal.Command.Add(p);
                }
                else
                {
                    q.Href = p.Href;
                    q.Class = p.Class;
                    q.IconCls = p.IconCls;
                    q.Plain = p.Plain;
                    q.CommandName = p.CommandName;
                    q.Index = p.Index;
                    q.Location = p.Location;
                    dal.Entry(q).State = EntityState.Modified;
                }
                dal.SaveChanges();
            }
        }

    }
}
