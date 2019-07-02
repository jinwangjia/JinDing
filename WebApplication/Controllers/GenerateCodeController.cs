using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class GenerateCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取一个GUID编码
        /// </summary>
        /// <returns></returns>
        public IActionResult GuidCode()
        {
            return Json(new { state = "ok", data = Guid.NewGuid().ToString("N") });
        }

        /// <summary>
        /// 汉字转首字母
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IActionResult FirstSpell(string value)
        {
            return Json(new { state = "ok", data = PingYinHelper.FirstSpell(value) });
        }
    }
}