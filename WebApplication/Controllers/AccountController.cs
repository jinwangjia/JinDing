
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Model;
using SqlDal;
using System;
using WebApplication.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        IDistributedCache Cache;
        public AccountController(IDistributedCache Cache)
        {
            this.Cache = Cache;
        }
        //
        // GET: /Account/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogOn()
        {
            return View(new AccountLogOnModel());
        }

        [HttpPost]
        public IActionResult LogOn(AccountLogOnModel model)
        {
            if (ModelState.IsValid)
            {
                var administratorDal = new AdministratorDal();
                try
                {
                    var p = administratorDal.FindByAccounts(model.Accounts.ToLower());
                    if (p!=null)
                    {
                        //Url.IsLocalUrl(returnUrl)
                        CryptoHelper helper = new CryptoHelper();
                        if (p.PassWord.Trim()==helper.Encrypt(model.Password ))
                        {
                            Cache.SetString("CurrentAdmin", p.AdministratorId);
                            HttpContext.Session.SetString("CurrentAdmin", p.AdministratorId);
                            var logMode = new LogDefinition()
                            {
                                Content = "登录",
                                AdminName = p.Name,
                                AfterUpdate = "",
                                BeforeUpdate = "",
                                UpdateDateTime = DateTime.Now,
                            };
                            var logDal = new LogDal();
                            logDal.Add(logMode);
                            return RedirectToAction("Index", "Frame");
                        }
                        else
                        {
                            ModelState.AddModelError("", "密码不正确.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "找不到该账号.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult TimeOut()
        {
            return View();
        }
    }
}
