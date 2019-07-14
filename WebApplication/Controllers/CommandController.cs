using Microsoft.AspNetCore.Mvc;
using Model;
using SqlDal;
using System;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CommandController : Controller
    {
        CommandDal CommandDal = new CommandDal();
        //
        // GET: /Command/

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JQueryIndex(string functionId)
        {
            var list = CommandDal.QueryByFunctionId(functionId);
            return Json(list);
        }

        public IActionResult Add(string functionId)
        {
            var model = new CommandAddModel()
            {
                FunctionId = functionId,
                Href = "#",
                Class = "easyui-linkbutton",
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CommandAddModel model)
        {
            try
            {
                var p = new CommandDefinition()
                {
                    CommandId = Guid.NewGuid().ToString("N"),
                    FunctionId = model.FunctionId,
                    Href = model.Href,
                    Class = model.Class,
                    IconCls = model.IconCls,
                    Plain = model.Plain,
                    OnClick = model.OnClick,
                    CommandName = model.CommandName,
                    Index = model.Index,
                    Location = model.Location,
                };
                CommandDal.Add(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        public IActionResult Update(string commandId)
        {
            var p = CommandDal.Find(commandId);
            var model = new CommandUpdateModel()
            {
                CommandId = p.CommandId,
                FunctionId = p.FunctionId,
                Href = p.Href,
                Class = p.Class,
                IconCls = p.IconCls,
                Plain = p.Plain,
                OnClick = p.OnClick,
                CommandName = p.CommandName,
                Index = p.Index,
                Location = p.Location,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CommandUpdateModel model)
        {
            try
            {
                var p = CommandDal.Find(model.CommandId);
                p.FunctionId = model.FunctionId;
                p.Href = model.Href;
                p.Class = model.Class;
                p.IconCls = model.IconCls;
                p.Plain = model.Plain;
                p.OnClick = model.OnClick;
                p.CommandName = model.CommandName;
                p.Index = model.Index;
                p.Location = model.Location;
                CommandDal.Update(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Delete(string commandId)
        {
            try
            {
                var p = CommandDal.Find(commandId);
                CommandDal.Remove(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

    }
}

//CommandId
//FunctionId
//Href
//Class
//IconCls
//Plain
//OnClick
//CommandName
//Index