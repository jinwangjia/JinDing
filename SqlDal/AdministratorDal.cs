using Model;
using System.Linq;

namespace SqlDal
{
    public class AdministratorDal:ParentDal<AdministratorDefinition>
    {

        public AdministratorDefinition FindByAccounts(string accounts)
        {
            using (var dal = new BaseDal())
            {
                return dal.Administrator.SingleOrDefault(o => o.Accounts == accounts);
            }
        }


      
    }
}


 
 
 
 
 
 
 