using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using SqlDal;
using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FrameController : Controller
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin
        {
            get
            {
                var dal = new AdministratorDal();
                var p = dal.Find(HttpContext.Session.GetString("CurrentAdmin"));
                return  p;
            }
            set
            {
                HttpContext.Session.SetString("CurrentAdmin", value.AdministratorId);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (CurrentAdmin == null)
            {
                Response.Redirect("/Account/LogOn");
            }
        }

        //
        // GET: /Frame/

        public IActionResult Index()
        {
            var configDal = new ConfigDal();
            HttpContext.Items["themes"] = configDal.GetValue("主题", "bluelight");
            var dal = new FunctionDal();
            IList<FunctionDefinition> list = CurrentAdmin.SysAdmin ? dal.QueryDisplay() : dal.QueryDisplayByRoleId(CurrentAdmin.RoleId);

            var model = new FrameIndexModel()
            {
                CurrentAdmin = CurrentAdmin,
                FunctionList = list,
            };
            return View(model);
        }

        public IActionResult LoginOut()
        {
            CurrentAdmin = null;
            return RedirectToAction("LogOn", "Account");
        }

        public IActionResult ChangePassword()
        {
            var model = new FrameChangePassword
            {
                Accounts = CurrentAdmin.Accounts,
                Name = CurrentAdmin.Name,
                Phone = CurrentAdmin.Phone,
                OldPassword = "",
                NewPassword = "",
                ConfirmPassword = "",
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(FrameChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var dal = new AdministratorDal();
                try
                {
                    CryptoHelper helper = new CryptoHelper();
                    var p = CurrentAdmin;
                    var old = dal.FindByAccounts(model.Accounts.Trim().ToLower());
                    if (old != null)
                    {
                        if (old.AdministratorId != p.AdministratorId)
                        {
                            ModelState.AddModelError("", "该账号已经被占用.");
                            return View(model);
                        }
                    }

                    if (model.OldPassword.Trim() == helper.Decrypt(p.PassWord.Trim()))
                    {
                        var logMode = new LogDefinition()
                        {
                            Content = "修改密码",
                            AdminName = p.Name,
                            AfterUpdate = "",
                            BeforeUpdate = "",
                            UpdateDateTime = DateTime.Now,
                        };
                        var logDal = new LogDal();
                        logDal.Add(logMode);
                        p.PassWord = helper.Encrypt(model.NewPassword);
                        p.Accounts = model.Accounts.Trim().ToLower();
                        dal.Update(p);
                        CurrentAdmin = null;
                        return RedirectToAction("LogOn", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "密码不正确.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            //model.OldPassword = "";
            //model.NewPassword = "";
            //model.ConfirmPassword = "";

            return View(model);
        }

    }
}