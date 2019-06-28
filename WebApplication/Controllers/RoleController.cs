using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using SqlDal;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RoleController : AfterLogOnController
    {
        //
        // GET: /Role/
        RoleDal RoleDal = new RoleDal();

        public IActionResult Index()
        {
            var model = new RoleIndexModel()
            {
                CurrentAdmin=CurrentAdmin,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult JsonIndex()
        {
            return Json(RoleDal.Query());
        }

        public IActionResult Add()
        {
            var model = new RoleAddModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(RoleAddModel model)
        {
            try
            {
                var p = new RoleDefinition()
                {
                    RoleId= Guid.NewGuid().ToString(),
                    Name=model.Name,
                };
                RoleDal.Add(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult Update(string roleId)
        {
            var p = RoleDal.Find(roleId);
            var model = new RoleUpdateModel()
            {
                RoleId=p.RoleId,
                Name=p.Name.Trim(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(RoleUpdateModel model )
        {
            try
            {
                var p = RoleDal.Find(model.RoleId);
                p.Name = model.Name;
                RoleDal.Update(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Delete(string roleId)
        {
            try
            {
                var p = RoleDal.Find(roleId);
                RoleDal.Remove(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Save(RoleSaveModel model, FormCollection collection)
        {
            try
            {
                var roleAndFunctonIds = collection["FunctionIds"];
                var roleAndCommandIds = collection["CommandIds"];
                RoleDal.Update(model.RoleId,
                    roleAndFunctonIds.Count == 0 ? new List<string>() : roleAndFunctonIds.ToList(),
                    roleAndCommandIds.Count == 0 ? new List<string>() : roleAndCommandIds.ToList());
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult QueryRoleByRoleId(string roleId)
        {
            var roleAndCommandDal = new RoleAndCommandDal();
            var roleAndCommandList = roleAndCommandDal.QueryByRoleId(roleId).Select(o=>o.CommandId).ToList();
            var roleAndFunctionDal = new RoleAndFunctionDal();
            var roleAndFunctionList = roleAndFunctionDal.QueryByRoleId(roleId).Select(o => o.FunctionId).ToList();
            return Json(roleAndCommandList.Concat(roleAndFunctionList).ToList());
        }

    }
}
