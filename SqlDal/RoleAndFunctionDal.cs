using Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    /// <summary>
    /// 角色功能对照表
    /// </summary>
    public class RoleAndFunctionDal : ParentDal<RoleAndFunctionDefinition>
    {

        public IList<RoleAndFunctionDefinition> QueryByRoleId(string roleId)
        {
            using (var dal = new BaseDal())
            {
                return dal.RoleAndFunction.Where(o => o.RoleId == roleId).ToList();
            }
        }
    }
}
