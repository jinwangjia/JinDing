using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    public class TableColumnDal:ParentDal<TableColumnDefinition>
    {
        public IList<TableColumnDefinition> QueryByFunctionIdAndVisible(string functionId)
        {
            using (var dal = new BaseDal())
            {
                return dal.TableColumn.Where(o => (o.FunctionId == functionId) && (o.Visible)).OrderBy(o => o.Index).ToList();
            }
        }

        public TableColumnDefinition FindByFunctionIdTableColumnId(string functionId, string tableColumnId)
        {
            using (var dal = new BaseDal())
            {
                return dal.TableColumn.SingleOrDefault(o => o.FunctionId == functionId && (o.TableColumnId == tableColumnId));
            }
        }

        public int GetMaxIndexByFunctionId(string functionId)
        {
            using (var dal = new BaseDal())
            {
                try
                {
                    return dal.TableColumn.Where(o => o.FunctionId == functionId).Max(o => o.Index);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public void DeleteByFunctionId(string functionId)
        {
            using (var dal = new BaseDal())
            {
                var list = dal.TableColumn.Where(o => o.FunctionId == functionId).ToList();
                if (list.Count() > 0)
                {
                    dal.TableColumn.RemoveRange(list);
                    dal.SaveChanges();
                }
            }
        }

        public bool HasByFunctionId(string functionId)
        {
            using (var dal = new BaseDal())
            {
                return dal.TableColumn.Any(o => o.FunctionId == functionId);
            }
        }

        public IList<TableColumnDefinition> QueryByFunctionId(string functionId)
        {
            using (var dal = new BaseDal())
            {
                return dal.TableColumn.Where(o => o.FunctionId == functionId).OrderBy(o => o.Index).ToList();
            }
        }

        public void AndOrUpdate(TableColumnDefinition p)
        {
            using (var dal = new BaseDal())
            {
                var q = dal.TableColumn.SingleOrDefault(o => (o.FunctionId == p.FunctionId) && (o.Field == p.Field));
                if (q == null)
                {
                    dal.TableColumn.Add(p);
                }
                else
                {
                    q.Align = p.Align;
                    q.Width = p.Width;
                    q.Name = p.Name;
                    q.Format = p.Format;
                    q.Index = p.Index;
                    dal.Entry(q).State = EntityState.Modified;
                }
                dal.SaveChanges();
            }
        }
    }
}
