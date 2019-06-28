using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using SqlDal;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 配方
    /// </summary>
    public class FormulaController : AfterLogOnController
    {
        private readonly IMapper mapper;

        public FormulaController(IMapper mapper)
        {
            this.mapper = mapper;
        }

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
                            FormulaId = o.FormulaId,
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


        public IActionResult Add()
        {
            var model = new FormulaAddModel()
            {
                
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(FormulaAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new FormulaDal();
                var p = mapper.Map<FormulaDefinition>(model);
                dal.Add(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }

        }

        public IActionResult Update(string formulaId)
        {
            var dal = new FormulaDal();
            var p = dal.Find(formulaId);
            var model = mapper.Map<FormulaUpdateModel>(p);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(FormulaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new FormulaDal();
                var p = dal.Find(model.FormulaId);
                mapper.Map(model, p);
                dal.Update(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Delete(string formulaId)
        {
            var dal = new FormulaDal();
            var p = dal.Find(formulaId);
            if (p == null)
            {
                return Json(new { state = "error", data = "找不到这一条数据" });
            }

            try
            {
                dal.Remove(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }
    }
}