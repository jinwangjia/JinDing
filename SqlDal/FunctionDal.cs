using Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    /// <summary>
    /// 功能表
    /// </summary>
    public class FunctionDal : ParentDal<FunctionDefinition>
    {
        public IList<FunctionDefinition> Query()
        {
            using (var dal = new BaseDal())
            {
                return dal.Function.OrderBy(o => o.Postion).ToList();
            }
        }

        public IList<FunctionDefinition> QueryDisplay()
        {
            using (var dal = new BaseDal())
            {
                return dal.Function.Where(o => o.Display).OrderBy(o => o.Postion).ToList();
            }
        }

        public IList<FunctionDefinition> QueryDisplayByRoleId(string roleId)
        {
            using (var dal = new BaseDal())
            {
                var tree = from item in dal.Function
                           join roleAndFunction in dal.RoleAndFunction on item.FunctionId equals roleAndFunction.FunctionId
                           where ((item.Display) && (item.FunctionId == roleAndFunction.FunctionId) 
                           && (roleAndFunction.RoleId == roleId))
                           select item;

                return (tree).ToList();
            }
        }



        public IList<FunctionDefinition> QueryParentOrderByName()
        {
            using (var dal = new BaseDal())
            {
                return dal.Function.Where(o => o.ParentId == "0").OrderBy(o => o.Name).ToList();
            }
        }


        public void RemoveById(string functionId)
        {
            using (var dal = new BaseDal())
            {
                var p = dal.Function.Find(functionId);
                dal.Function.Remove(p);
                dal.SaveChanges();
            }
        }

        public IList<FunctionDefinition> QueryByParentId(string id)
        {
            using (var dal = new BaseDal())
            {
                return (from o in dal.Function where o.ParentId == id select o).ToArray();
            }
        }

        public FunctionDefinition FindByPage(string page)
        {
            using (var dal = new BaseDal())
            {
                return dal.Function.Single(o => o.Page == page);
            }
        }
    }
}
