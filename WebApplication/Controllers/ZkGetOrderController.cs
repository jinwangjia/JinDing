using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ZkGetOrderController : AfterLogOnController
    {
        public IActionResult Index()
        {
            var model = new ZkGetOrderJsonIndexModel()
            {
                CurrentAdmin = this.CurrentAdmin,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult JsonIndex()
        {

            return Json(1);
        }

        public IActionResult Add()
        {

            return Json(1);
        }

        [HttpPost]
        public IActionResult Add(ZkGetOrderAddModel model)
        {

            return Json(1);
        }

        public IActionResult Update()
        {

            return Json(1);
        }

        [HttpPost]
        public IActionResult Update(ZkGetOrderUpdateModel model)
        {

            return Json(1);
        }
    }


}