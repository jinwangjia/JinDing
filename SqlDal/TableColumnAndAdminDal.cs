using Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    public class TableColumnAndAdminDal:ParentDal<TableColumnAndAdminDefinition>
    {
        public IList<TableColumnDefinition> QueryByAdministratorIdFunctionIdAndVisible(string administratorId, string functionId)
        {
            using (var dal = new BaseDal())
            {
                var list = from tableColumn in dal.TableColumn
                           from tableColumnAndAdmin in dal.TableColumnAndAdmin
                           where ((tableColumn.FunctionId == tableColumnAndAdmin.FunctionId) && (tableColumn.TableColumnId == tableColumnAndAdmin.TableColumnId) && (tableColumnAndAdmin.AdministratorId == administratorId) && (tableColumnAndAdmin.FunctionId == functionId) && (tableColumn.Visible))
                           select tableColumn;
                return list.ToList().OrderBy(o => o.Index).ToList();
            }
        }

        public void DeleteByFunctionId(string functionId)
        {
            using (var dal = new BaseDal())
            {
                var list = dal.TableColumnAndAdmin.Where(o => o.FunctionId == functionId).ToList();
                if (list.Count() > 0)
                {
                    dal.TableColumnAndAdmin.RemoveRange(list);
                    dal.SaveChanges();
                }
            }
        }

        public IList<TableColumnDefinition> QueryByAdministratorIdFunctionId(string administratorId, string functionId)
        {
            using (var dal = new BaseDal())
            {
                var list = from tableColumn in dal.TableColumn
                           from tableColumnAndAdmin in dal.TableColumnAndAdmin
                           where ((tableColumn.FunctionId == tableColumnAndAdmin.FunctionId) && (tableColumn.TableColumnId == tableColumnAndAdmin.TableColumnId) && (tableColumnAndAdmin.AdministratorId == administratorId) && (tableColumnAndAdmin.FunctionId == functionId))
                           select tableColumn;
                return list.ToList().OrderBy(o => o.Index).ToList();
            }
        }

        public IList<string> QueryTableColumnIdByAdministratorIdFunctionId(string administratorId, string functionId)
        {
            using (var dal = new BaseDal())
            {
                return dal.TableColumnAndAdmin.Where(o => ((o.AdministratorId == administratorId) && (o.FunctionId == functionId))).Select(o => o.TableColumnId).ToList();
            }
        }

        public void Update(string functionId,string administratorId, IList<string> tableColumnIds)
        {
            using (var dal = new BaseDal())
            {
                var list = dal.TableColumnAndAdmin.Where(o => ((o.FunctionId == functionId) && (o.AdministratorId == administratorId)));

                var tableColumnList = dal.TableColumn.Where(o => o.FunctionId == functionId);
             
                dal.TableColumnAndAdmin.RemoveRange(list);
                foreach (var p in tableColumnIds)
                {
                    var tableColumn = tableColumnList.SingleOrDefault(o => o.TableColumnId == p);
                    if (tableColumn == null)
                        continue;

                    dal.TableColumnAndAdmin.Add(new TableColumnAndAdminDefinition()
                    {
                        TableColumnId = p,
                        FunctionId = functionId,
                        AdministratorId = administratorId,
                    });
                }
                dal.SaveChanges();
            }
        }
    }
}
