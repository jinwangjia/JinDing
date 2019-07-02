using Infrastructure;
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
    public class AdministratorController : AfterLogOnController
    {
        //
        // GET: /Administrator/
        AdministratorDal AdministratorDal = new AdministratorDal();

        RoleDal RoleDal = new RoleDal();

        public IActionResult Index()
        {
            var model = new AdministratorIndexModel()
            {
                CurrentAdmin=CurrentAdmin,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult JsonIndex(AdministratorJsonIndexModel model)
        {
            if (model.StationNo == "0")
                model.StationNo = null;


            var dal = new AdministratorDal();
            var list = dal.Query();
            var list2 = (from o in list
                         select new //AdministratorDefinition()
                         {
                             AdministratorId = o.AdministratorId,
                             SysAdmin = o.SysAdmin ? "系统管理员" : "管理员",
                             Name = o.Name,
                             Accounts = o.Accounts,
                             PassWord = o.PassWord,
                             ReWritePassWord = o.ReWritePassWord,
                             Phone = o.Phone,
                             RoleId = o.RoleId,
                         }).ToList();

            var grid = new
            {
                total = 0,
                rows = list2,
            };

            return Json(grid);
        }

        public IActionResult Add()
        {
            var model = new AdministratorAddModel()
            {
                RoleList = RoleDal.Query(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AdministratorAddModel model)
        {
            var oldAdmin = AdministratorDal.FindByAccounts(model.Accounts);
            if (oldAdmin != null)
            {
                return Json("该登录账号已经占用");
            }

            try
            {
                CryptoHelper helper = new CryptoHelper();

                var p = new AdministratorDefinition()
                {
                    AdministratorId = Guid.NewGuid().ToString(),
                    SysAdmin = false,
                    Name = model.Name,
                    PassWord = helper.Encrypt(model.PassWord.Trim()),
                    Phone = model.Phone,
                    Accounts = model.Accounts.ToLower(),
                    ReWritePassWord = true,
                    RoleId = model.RoleId,
                };
                AdministratorDal.Add(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult AddSysAdmin()
        {
            var model = new AdministratorAddSysAdminModel()
            {
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSysAdmin(AdministratorAddSysAdminModel model)
        {
            var oldAdmin = AdministratorDal.FindByAccounts(model.Accounts);
            if (oldAdmin != null)
            {
                return Json("该登录账号已经占用");
            }

            try
            {
                CryptoHelper helper = new CryptoHelper();
                var p = new AdministratorDefinition()
                {
                    AdministratorId = Guid.NewGuid().ToString(),
                    SysAdmin = true,
                    Name = model.Name,
                    PassWord = helper.Encrypt(model.PassWord.Trim()),
                    Phone = model.Phone,
                    Accounts = model.Accounts.ToLower(),
                    ReWritePassWord = true,
                    //BureauNo = null,
                    //StationNo = null,
                    RoleId = null,
                };
                AdministratorDal.Add(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult Update(string administratorId)
        {
            CryptoHelper helper = new CryptoHelper();
            var p = AdministratorDal.Find(administratorId);
            if (p.SysAdmin)
            {
                var model = new AdministratorUpdateSysAdminModel()
                {
                    AdministratorId = p.AdministratorId,
                    Name = p.Name,
                    Accounts = p.Accounts,
                    PassWord = helper.Decrypt( p.PassWord),
                    Phone = p.Phone,
                };
                return View("UpdateSysAdmin", model);
            }
            else
            {
                var model = new AdministratorUpdateModel()
                {
                    RoleList = RoleDal.Query(),
                    AdministratorId = p.AdministratorId,
                    Name = p.Name,
                    Accounts = p.Accounts.ToLower(),
                    PassWord = helper.Decrypt(p.PassWord),
                    Phone = p.Phone,
                    RoleId = p.RoleId,
                };
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Update(AdministratorUpdateModel model)
        {
            try
            {
                CryptoHelper helper = new CryptoHelper();
                var p = AdministratorDal.Find(model.AdministratorId);
                if (p.Accounts != model.Accounts.ToLower())
                {
                    var oldAdmin = AdministratorDal.FindByAccounts(model.Accounts);
                    if (oldAdmin != null && (oldAdmin.AdministratorId != model.AdministratorId))
                    {
                        return Json("该登录账号已经占用");
                    }
                }
                p.AdministratorId = model.AdministratorId;
                p.Name = model.Name;
                p.Accounts = model.Accounts;
                if (!string.IsNullOrWhiteSpace(model.PassWord))
                {
                    p.PassWord = helper.Encrypt(model.PassWord.Trim());
                }
                p.Phone = model.Phone;
                p.RoleId = model.RoleId;
                AdministratorDal.Update(p);
                return Json(1);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateSysAdmin(AdministratorUpdateSysAdminModel model)
        {
            try
            {
                CryptoHelper helper = new CryptoHelper();
                var p = AdministratorDal.Find(model.AdministratorId);
                if (p.Accounts != model.Accounts.ToLower())
                {
                    var oldAdmin = AdministratorDal.FindByAccounts(model.Accounts);
                    if (oldAdmin != null)
                    {
                        return Json("该登录账号已经占用");
                    }
                }
                p.AdministratorId = model.AdministratorId;
                p.Name = model.Name;
                p.Accounts = model.Accounts.ToLower();
                if (!string.IsNullOrWhiteSpace(model.PassWord))
                {
                    p.PassWord = helper.Encrypt(model.PassWord.Trim());
                }
                p.Phone = model.Phone;
                AdministratorDal.Update(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult Delete(string administratorId)
        {
            try
            {
                var p = AdministratorDal.Find(administratorId);
                AdministratorDal.Remove(p);
                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }





    }
}
