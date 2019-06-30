using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}