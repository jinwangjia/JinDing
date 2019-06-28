using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlDal;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 配方
    /// </summary>
    public class FormulaController : AfterLogOnController
    {
        public IActionResult Index()
        {
            var model = new FormulaJsonIndexModel()
            {
                CurrentAdmin = CurrentAdmin,
                //BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                //EndDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
            };
            return View(model);
        }

        public IActionResult JsonIndex(FormulaJsonIndexModel model)
        {
            //if (model.BeginDateTime == null)
            //    model.BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            //if (model.EndDateTime == null)
            //    model.EndDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var dal = new FormulaDal();
            var param = new FormulaDal.QueryByParam1In()
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
                            FormulaName = o.FormulaName,
                            FormulaCode = o.FormulaCode,
                            FormulaPinYin = o.FormulaPinYin,
                            CreateDateTime = o.CreateDateTime.ToString(),
                            UpdateDateTime = o.UpdateDateTime.ToString(),
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