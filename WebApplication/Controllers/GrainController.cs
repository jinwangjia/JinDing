using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using SqlDal;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 物料
    /// </summary>
    public class GrainController : AfterLogOnController
    {
        public IActionResult Index()
        {
            var model = new GrainJsonIndexModel()
            {
                CurrentAdmin = CurrentAdmin,
                //BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                //EndDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
            };
            return View(model);
        }

        public IActionResult JsonIndex(GrainJsonIndexModel model)
        {
            //if (model.BeginDateTime == null)
            //    model.BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            //if (model.EndDateTime == null)
            //    model.EndDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var dal = new GrainDal();
            var param = new GrainDal.QueryByParam1In()
            {
                //BeginDateTime = DateTime.Parse(model.BeginDateTime),
                //EndDateTime = DateTime.Parse(model.EndDateTime),
                Rows = model.Rows,
                Page = model.Page,
            };
            var list = dal.QueryByParam1(param);
            var list2 = from o in list
                        select new
                        {
                            GrainName = o.GrainName,
                            GrainCode = o.GrainCode,
                            GrainPinYin = o.GrainPinYin,
                        };

            var grid = new
            {
                total = param.Total,
                rows = list2,
            };
            return Json(grid);
        }
    }
}