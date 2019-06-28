using Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleDal : ParentDal<RoleDefinition>
    {
        public void Update(string roleId, IList<string> functionIds, IList<string> commandIds)
        {
            using (var dal = new BaseDal())
            {
                var oldRoleAndFunction = dal.RoleAndFunction.Where(o => o.RoleId == roleId);
                dal.RoleAndFunction.RemoveRange(oldRoleAndFunction);
                var oldRoleAndCommand = dal.RoleAndCommand.Where(o => o.RoleId == roleId);
                dal.RoleAndCommand.RemoveRange(oldRoleAndCommand);
                foreach (var p in functionIds)
                {
                    dal.RoleAndFunction.Add(new RoleAndFunctionDefinition() { RoleId = roleId, FunctionId = p });
                }
                foreach (var p in commandIds)
                {
                    dal.RoleAndCommand.Add(new RoleAndCommandDefinition() { RoleId = roleId, CommandId = p });
                }
                dal.SaveChanges();
            }
        }
    }
}
