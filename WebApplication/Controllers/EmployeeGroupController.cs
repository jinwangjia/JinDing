using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using SqlDal;
using System;
using System.Collections.Generic;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 班次
    /// </summary>
    public class EmployeeGroupController : AfterLogOnController
    {
        private readonly IMapper mapper;

        public EmployeeGroupController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new EmployeeGroupIndexModel()
            {
                CurrentAdmin= CurrentAdmin,
            };
            return View(model);
        }

        public IActionResult JsonIndex()
        {
            var administratorDal = new AdministratorDal();
            var administratorList = administratorDal.Query();
            var func = new Func<string, string>((administratorId) => {
                if (string.IsNullOrEmpty(administratorId))
                    return string.Empty;
                var p = administratorList.SingleOrDefault(o => o.AdministratorId == administratorId);
                if (p == null)
                    return string.Empty;
                return p.Name;
            });
            var dal = new EmployeeGroupDal();

            var list = dal.Query();
            var dtoList = mapper.Map<List<EmployeeGroupJsonIndexModel>>(list);
            dtoList.ForEach(o =>
            {
                o.MonitorName = func(o.MonitorId);
                o.OtherEmployeesName1 = func(o.OtherEmployeesId1);
                o.OtherEmployeesName2 = func(o.OtherEmployeesId2);
            });
            return Json(dtoList);
        }

        public IActionResult Add()
        {
            var dal = new AdministratorDal();
            var model = new EmployeeGroupAddModel()
            {
                Administrators= dal.Query(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(EmployeeGroupAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new EmployeeGroupDal();
                var p = mapper.Map<EmployeeGroupDefinition>(model);
                dal.Add(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }

        }

        public IActionResult Update(string employeeGroupId)
        {
            var dal = new EmployeeGroupDal();
            var p = dal.Find(employeeGroupId);
            var model = mapper.Map<EmployeeGroupUpdateModel>(p);
            var administratorDal = new AdministratorDal();
            model.Administrators = administratorDal.Query();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(EmployeeGroupUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new EmployeeGroupDal();
                var p = mapper.Map<EmployeeGroupDefinition>(model);
                dal.Update(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Delete(string employeeGroupId)
        {
            var dal = new EmployeeGroupDal();
            var p = dal.Find(employeeGroupId);
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