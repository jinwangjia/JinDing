using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SqlDal;
using WebApplication.Models;
using Model;

namespace WebApplication.Controllers
{
    public class ZkGetOrderController : AfterLogOnController
    {
        private readonly IMapper mapper;

        public ZkGetOrderController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new ZkGetOrderJsonIndexParamModel()
            {
                CurrentAdmin = this.CurrentAdmin,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult JsonIndex(ZkGetOrderJsonIndexParamModel model)
        {
            var dal = new ZkGetOrderDal();
            var param = mapper.Map<ZkGetOrderDal.QueryByParamIn>(model);
            var list = dal.QueryByParam(param);
            var list2 = mapper.Map<List<ZkGetOrderJsonIndexItemModel>>(list);
            var grid = new
            {
                total = param.Total,
                rows = list2,
            };
            return Json(grid);
        }

        public IActionResult Add()
        {
            var formulaDal = new FormulaDal();
            var model = new ZkGetOrderAddModel()
            {
                FormulaList = formulaDal.Query(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ZkGetOrderAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new ZkGetOrderDal();
                var p = mapper.Map<ZkGetOrderDefinition>(model);
                p.FormulaCode = "";
                p.IsPublic = false;
                dal.Add(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        public IActionResult Update(string zkGetOrderId)
        {
            var dal = new ZkGetOrderDal();
            var formulaDal = new FormulaDal();
            var p = dal.Find(zkGetOrderId);
            var model = mapper.Map<ZkGetOrderUpdateModel>(p);
            model.FormulaList = formulaDal.Query();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ZkGetOrderUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new ZkGetOrderDal();
                var p = dal.Find(model.ZkGetOrderId);
                mapper.Map(model, p);
                dal.Update(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

    }


}