using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlDal;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : AfterLogOnController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var dal = new AdministratorDal();
            var model = new HomeIndexModel()
            {

                Count = dal.Query().Count,
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Desktop()
        {
            var logDal = new LogDal();

            var model = new HomeModelDesktop()
            {
                UserCount = 0,
                DeviceCount = 0,
                DeviceCountOfPowerFlag = 0,
                Log = logDal.QueryNearN(10),
                DeviceCountOfOnLine = 0,
            };
            return View(model);
        }
    }
}
