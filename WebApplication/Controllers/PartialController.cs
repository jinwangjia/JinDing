using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 分部视图
    /// </summary>
    public class PartialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}