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
    public class TableColumnController : AfterLogOnController
    {
        //
        // GET: /TableColumn/

        TableColumnDal TableColumnDal = new TableColumnDal();

        public IActionResult Index(TableColumnIndexModel model)
        {
            if (CurrentAdmin.SysAdmin)
            {
                return RedirectToAction("IndexAdmin", new TableColumnIndexAdminModel()
                {
                    CurrentAdmin = CurrentAdmin,
                    FunctionId = model.FunctionId,
                    ReturnUrl = model.ReturnUrl,
                });
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult JsonIndex(string functionId)
        {
            var dal = new TableColumnDal();
            var list = dal.QueryByFunctionId(functionId);
            return Json(list);
        }

        public IActionResult Save(TableColumnSaveModel model, FormCollection collection)
        {
            try
            {
                var dal = new TableColumnAndAdminDal();
                var TableColumnId = collection["TableColumnId"];
                dal.Update(model.FunctionId,CurrentAdmin.AdministratorId, TableColumnId.Count == 0 ? new List<string>() : TableColumnId.ToList());
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        public IActionResult Rebuild(TableColumnRebuildModel model)
        {
            try
            {
                var tableColumnAndAdminDal = new TableColumnAndAdminDal();
                tableColumnAndAdminDal.DeleteByFunctionId(model.FunctionId);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        public IActionResult IndexAdmin(TableColumnIndexAdminModel model)
        {
            return View(model);
        }

        public IActionResult Add(string functionId)
        {
            var model = new TableColumnAndModel()
            {
                Visible = true,
                Width = 100,
                Align = "left",
                Index = TableColumnDal.GetMaxIndexByFunctionId(functionId) + 1,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TableColumnAndModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var p = new TableColumnDefinition()
                {
                    Field = model.Field,
                    Format = string.IsNullOrEmpty(model.Format) ? "" : model.Format,
                    FunctionId = model.FunctionId,
                    Align = model.Align,
                    Index = model.Index,
                    Name = model.Name,
                    TableColumnId = Guid.NewGuid().ToString("N"),
                    Visible = model.Visible,
                    Width = model.Width,
                };
                TableColumnDal.Add(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        public IActionResult Update(string functionId,string tableColumnId)
        {
            var p = TableColumnDal.FindByFunctionIdTableColumnId(functionId, tableColumnId);
            var model = new TableColumnUpdateModel()
            {
                Field = p.Field,
                Format = p.Format,
                FunctionId = p.FunctionId,
                Align = p.Align,
                Index = p.Index,
                Name = p.Name,
                TableColumnId = p.TableColumnId,
                Visible = p.Visible,
                Width = p.Width,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(TableColumnUpdateModel model)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var p = TableColumnDal.FindByFunctionIdTableColumnId(model.FunctionId, model.TableColumnId);
                p.Field = model.Field;
                p.Format = string.IsNullOrEmpty(model.Format) ? "" : model.Format;
                p.Align = model.Align;
                p.Index = model.Index;
                p.Name = model.Name;
                p.Visible = model.Visible;
                p.Width = model.Width;
                TableColumnDal.Update(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Delete(string functionId, string tableColumnId)
        {
            var p = TableColumnDal.FindByFunctionIdTableColumnId(functionId, tableColumnId);
            if (p==null)
            {
                return Json(new { state = "error", data = "找不到这一条数据" });
            }

            try
            {
                TableColumnDal.Remove(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

    }

   

}
