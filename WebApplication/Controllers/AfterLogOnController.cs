using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using SqlDal;

namespace WebApplication.Controllers
{
    public class AfterLogOnController : Controller
    {
        protected AdministratorDal AdministratorDal = new AdministratorDal();

        //当前用户
        public AdministratorDefinition CurrentAdmin
        {
            get
            {
                var dal = new AdministratorDal();
                var p = dal.Find(HttpContext.Session.GetString("CurrentAdmin"));
                return p;
            }
            set
            {
                HttpContext.Session.SetString("CurrentAdmin", value.AdministratorId);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (CurrentAdmin == null)
            {
                Response.Redirect("/Account/TimeOut");
            }
        }
    }
}