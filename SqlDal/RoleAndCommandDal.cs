using Model;
using System.Collections.Generic;
using System.Linq;

namespace SqlDal
{
    public class RoleAndCommandDal:ParentDal<RoleAndCommandDefinition>
    {
        public IList<RoleAndCommandDefinition> QueryByRoleId(string roleId)
        {
            using (var dal = new BaseDal())
            {
                return dal.RoleAndCommand.Where(o => o.RoleId == roleId).ToList();
            }
        }
    }
}
