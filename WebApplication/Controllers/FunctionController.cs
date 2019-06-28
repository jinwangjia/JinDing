using Microsoft.AspNetCore.Mvc;
using Model;
using SqlDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FunctionController : AfterLogOnController
    {

        public IActionResult JQueryLeftTree(string id)
        {
            if (!CurrentAdmin.SysAdmin)
            {
                return JQueryLeftTree2(id);
            }

            var dal = new FunctionDal();
            IList<FunctionDefinition> list = dal.Query();
            var tree = from item in list
                       where item.ParentId == id && item.Display
                       //where item.Display
                       orderby item.Postion
                       select new
                       {
                           id = item.FunctionId,
                           text = item.Name,
                           state = list.FirstOrDefault(o => o.ParentId == item.FunctionId) == null ? "open" : "closed",
                           attributes = new
                           {
                               page = item.Page
                           }
                       };
            return Json(tree);
        }

        public IActionResult JQueryLeftTree2(string id)
        {
            var dal = new FunctionDal();
            var roleAndFunctionDal = new RoleAndFunctionDal();
            var roleAndFunctionList = roleAndFunctionDal.QueryByRoleId(CurrentAdmin.RoleId);

            IList<FunctionDefinition> list = dal.Query();
            var tree = from item in list
                       join roleAndFunction in roleAndFunctionList on item.FunctionId equals roleAndFunction.FunctionId
                       where item.ParentId == id && item.Display
                       //where item.Display
                       orderby item.Postion
                       select new
                       {
                           id = item.FunctionId,
                           text = item.Name,
                           state = list.FirstOrDefault(o => o.ParentId == item.FunctionId) == null ? "open" : "closed",
                           attributes = new
                           {
                               page = item.Page
                           }
                       };
            return Json(tree);
        }

        public IActionResult Index()
        {
            var model = new FunctionIndexModel()
            {
                CurrentAdmin = CurrentAdmin,
            };
            return View(model);
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult JQueryTreeGrid(string id)
        {
            if (!CurrentAdmin.SysAdmin)
            {
                return JQueryTreeGrid2(id);
            }

            try
            {
                var dal = new FunctionDal();
                IList<FunctionDefinition> list = dal.Query();
                var tree = from item in list
                           where item.ParentId == id
                           orderby item.Postion
                           select new
                           {
                               functionId = item.FunctionId,
                               name = item.Name,
                               state = list.FirstOrDefault(o => o.ParentId == item.FunctionId) == null ? "open" : "closed",
                               parentId = item.ParentId,
                               parentName = list.FirstOrDefault(o => o.FunctionId == item.ParentId) == null ? ""
                               : list.FirstOrDefault(o => o.FunctionId == item.ParentId).Name,
                               page = item.Page,
                               display = item.Display ? "显示" : "隐藏",
                               postion = item.Postion,
                               op = "<ahref=\"/function/Delete?id=" + item.FunctionId + "\" onclick=\"return confirm('您确认要删除该记录吗?');\">删除</a>"
                           };
                return Json(tree);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult JQueryTreeGrid2(string id)
        {
            try
            {
                var dal = new FunctionDal();
                var roleAndFunctionDal = new RoleAndFunctionDal();
                var roleAndFunctionList = roleAndFunctionDal.QueryByRoleId(CurrentAdmin.RoleId);
                IList<FunctionDefinition> list = dal.Query();
                var tree = from item in list
                           join roleAndFunction in roleAndFunctionList on item.FunctionId equals roleAndFunction.FunctionId
                           where item.ParentId == id
                           orderby item.Postion
                           select new
                           {
                               functionId = item.FunctionId,
                               name = item.Name,
                               state = list.FirstOrDefault(o => o.ParentId == item.FunctionId) == null ? "open" : "closed",
                               parentId = item.ParentId,
                               parentName = list.FirstOrDefault(o => o.FunctionId == item.ParentId) == null ? ""
                               : list.FirstOrDefault(o => o.FunctionId == item.ParentId).Name,
                               page = item.Page,
                               display = item.Display ? "显示" : "隐藏",
                               postion = item.Postion,
                               op = "<ahref=\"/function/Delete?id=" + item.FunctionId + "\" onclick=\"return confirm('您确认要删除该记录吗?');\">删除</a>"
                           };
                return Json(tree);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        public IActionResult JQueryTreeGridAndCommand(string id)
        {
            try
            {
                var dal = new FunctionDal();
                IList<FunctionDefinition> list = dal.Query();
                var tree = from item in list
                           where item.ParentId == id
                           orderby item.Postion
                           select new
                           {
                               functionId = item.FunctionId,
                               name = item.Name,
                               state = list.FirstOrDefault(o => o.ParentId == item.FunctionId) == null ? "open" : "closed",
                               parentId = item.ParentId,
                               parentName = list.FirstOrDefault(o => o.FunctionId == item.ParentId) == null ? ""
                               : list.FirstOrDefault(o => o.FunctionId == item.ParentId).Name,
                               CommandIds = GetCommandIdAndName(item.FunctionId),
                           };
                return Json(tree);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        private IList<string> GetCommandIdAndName(string functionId)
        {
            CommandDal commandDal = new CommandDal();
            var retList = new List<string>();
            var list = commandDal.QueryByFunctionId(functionId);
            foreach (var p in list)
            {
                retList.Add(p.CommandName);
                retList.Add(p.CommandId);
            }
            return retList;
        }


        public IList<string> GetPages()
        {
            IList<string> pages = new List<string>();
            pages.Add("");

            Type[] actions = Assembly.GetExecutingAssembly().GetTypes();
            actions = (from o in actions
                       where (o.Namespace == this.GetType().Namespace)
                       orderby o.Name
                       select o).ToArray();
            foreach (Type p in actions)
            {
                MethodInfo[] functions = (from o in p.GetMethods()
                                          where o.ReturnType == typeof(IActionResult)
                                          orderby o.Name
                                          select o).ToArray();
                foreach (MethodInfo q in functions)
                {
                    pages.Add(string.Format("/{0}/{1}", p.Name.Replace("Controller", ""), q.Name));
                }
            }

            pages = pages.Distinct().ToList();

            return pages;
        }

        public IActionResult Add()
        {
            FunctionAddModel model = new FunctionAddModel();
            var dal = new FunctionDal();
            model.Functions = dal.QueryOrderByName();

            model.Pages = GetPages();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(FunctionAddModel model)
        {
            var dal = new FunctionDal();
            FunctionDefinition function = new FunctionDefinition();
            function.FunctionId = Guid.NewGuid().ToString();
            function.ParentId = model.ParentId;
            function.Name = model.Name;
            function.Icon = model.Icon;
            function.Page = model.Page;
            function.Display = model.Display;
            function.Postion = model.Postion;
            try
            {
                dal.Add(function);
                return Json(1);
            }
            catch
            {
                //ViewBag.Message = "";
                return Json(0);
            }
        }

        public IActionResult Delete(string id)
        {
            var dal = new FunctionDal();
            try
            {
                var list = dal.QueryByParentId(id);
                foreach (var p in list)
                    dal.RemoveById(p.FunctionId);
                dal.RemoveById(id);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult Update(string id)
        {
            var dal = new FunctionDal();
            FunctionUpdateModel model = new FunctionUpdateModel();
            model.Functions = dal.QueryOrderByName();

            model.Pages = GetPages();


            FunctionDefinition function = dal.Find(id);
            model.FunctionId = function.FunctionId;
            model.ParentId = function.ParentId;
            model.Name = function.Name;
            model.Icon = function.Icon;
            model.Page = function.Page;
            model.Display = function.Display;
            model.Postion = function.Postion;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(FunctionUpdateModel model)
        {
            var dal = new FunctionDal();
            model.Functions = dal.QueryOrderByName();
            FunctionDefinition function = dal.Find(model.FunctionId);
            function.ParentId = model.ParentId;
            function.Name = model.Name;
            function.Icon = model.Icon;
            function.Page = model.Page;
            function.Display = model.Display;
            function.Postion = model.Postion;
            try
            {
                dal.Update(function);
                return Json(1);
            }
            catch
            {
                ViewBag.Message = "";
                return Json(0);
            }
        }


    }
}