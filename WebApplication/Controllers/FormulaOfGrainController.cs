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
    /// 配方之物料表
    /// </summary>
    public class FormulaOfGrainController : Controller
    {
        private readonly IMapper mapper;

        public FormulaOfGrainController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JsonIndex(string formulaId,int grainTypeId)
        {
            var formulaOfGrainDal = new FormulaOfGrainDal();
            var formulaOfGrainList = formulaOfGrainDal.QueryByFormulaIdGrainTypeId(formulaId, grainTypeId);
            //var list = formulaOfGrainList.Select(o => new
            //{
            //    FormulaId = o.FormulaOfGrain.FormulaId,
            //    GrainId = o.FormulaOfGrain.GrainId,
            //    Amount = o.FormulaOfGrain.Amount,
            //    GrainName = o.Grain.GrainName,
            //});
            var grid = new
            {
                total = formulaOfGrainList.Count(),
                rows = formulaOfGrainList,
            };
            return Json(grid);
        }


        public IActionResult Add(string formulaId,int grainTypeId)
        {
            var grainDal = new GrainDal();
            var model = new FormulaOfGrainAddModel()
            {
                FormulaId = formulaId,
                GrainTypeId = grainTypeId,
                Grains = grainDal.QueryByGrainTypeId(grainTypeId),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(FormulaOfGrainAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new FormulaOfGrainDal();
                var p = mapper.Map<FormulaOfGrainDefinition>(model);
                dal.Add(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }

        }

        public IActionResult Update(string formulaId, string grainId)
        {
            var formulaOfGrainDal = new FormulaOfGrainDal();
            var grainDal = new GrainDal();
            var formulaOfGrain = formulaOfGrainDal.Find(formulaId, grainId);
            var model = mapper.Map<FormulaOfGrainUpdateModel>(formulaOfGrain);
            var p = grainDal.Find(grainId);
            model.GrainName = p.GrainName;
            model.GrainTypeId = p.GrainTypeId;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(FormulaOfGrainUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new FormulaOfGrainDal();
                var p = dal.Find(model.FormulaId,model.GrainId);
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
        public IActionResult Delete(string formulaId, string grainId)
        {
            var dal = new FormulaOfGrainDal();
            var p = dal.Find(formulaId, grainId);
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