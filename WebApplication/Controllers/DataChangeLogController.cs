using System;
using SqlDal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class DataChangeLogController : AfterLogOnController
    {
        public IActionResult Index()
        {
            var model = new DataChangeLogJsonIndexModel()
            {
                CurrentAdmin = CurrentAdmin,
                BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                EndDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
            };
            return View(model);
        }

        public IActionResult JsonIndex(DataChangeLogJsonIndexModel model)
        {
            if (model.BeginDateTime == null)
                model.BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            if (model.EndDateTime == null)
                model.EndDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var dal = new DataChangeLogDal();
            var param = new DataChangeLogDal.QueryByParam1In()
            {
                BeginDateTime = DateTime.Parse(model.BeginDateTime),
                EndDateTime = DateTime.Parse(model.EndDateTime),
                Rows = model.Rows,
                Page = model.Page,
            };
            var list = dal.QueryByParam1(param);
            var list2 = from o in list
                        select new
                        {
                            Content = o.Content,
                            AdminName = o.AdminName,
                            BeforeUpdate = o.BeforeUpdate,
                            AfterUpdate = o.AfterUpdate,
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

