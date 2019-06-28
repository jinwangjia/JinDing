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
    /// 仓料对照
    /// </summary>
    public class GranariesController : AfterLogOnController
    {
        public IActionResult Index()
        {
            var model = new GranariesJsonIndexModel()
            {
                CurrentAdmin = CurrentAdmin,
                //BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                //EndDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
            };
            return View(model);
        }

        public IActionResult JsonIndex(GranariesJsonIndexModel model)
        {
            //if (model.BeginDateTime == null)
            //    model.BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            //if (model.EndDateTime == null)
            //    model.EndDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var dal = new GranariesDal();
            var param = new GranariesDal.QueryByParam1In()
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
                            GranariesName = o.GranariesName,
                            GranariesOrder = o.GranariesOrder,
                            BrotherGranariesId = o.BrotherGranariesId,
                            MaxCapacity = o.MaxCapacity,
                            CurrentCapacity = o.CurrentCapacity,
                            GrainId = o.GrainId,
                            AdvanceWeight1 = o.AdvanceWeight1,
                            AdvanceWeight2 = o.AdvanceWeight2,
                            AdvanceWeight3 = o.AdvanceWeight3,
                            TimeLength1 = o.TimeLength1,
                            TimeLength2 = o.TimeLength2,
                            TimeLength3 = o.TimeLength3,
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