﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using SqlDal;
using System;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 物料
    /// </summary>
    public class GrainController : AfterLogOnController
    {
        private readonly IMapper mapper;

        public GrainController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new GrainJsonIndexModel()
            {
                CurrentAdmin = CurrentAdmin,
                //BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                //EndDateTime = DateTime.Now.ToString("yyyy-MM-dd"),
            };
            return View(model);
        }

        public IActionResult JsonIndex(GrainJsonIndexModel model)
        {
            //if (model.BeginDateTime == null)
            //    model.BeginDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            //if (model.EndDateTime == null)
            //    model.EndDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var dal = new GrainDal();
            var grainTypeDal = new GrainTypeDal();
            var grainTypeList = grainTypeDal.Query();
            var grainTypeFuc = new Func<int, string>((id) =>
            {
                var p = grainTypeList.SingleOrDefault(o => o.GrainTypeId == id);
                if (p == null)
                    return string.Empty;
                return p.GrainTypeName;
            });

            var grainType2Dal = new GrainType2Dal();
            var grainType2List = grainType2Dal.Query();
            var grainType2Fuc = new Func<int, string>((id) =>
            {
                var p = grainType2List.SingleOrDefault(o => o.GrainType2Id == id);
                if (p == null)
                    return string.Empty;
                return p.GrainType2Name;
            });
            var param = new GrainDal.QueryByParam1In()
            {
                //BeginDateTime = DateTime.Parse(model.BeginDateTime),
                //EndDateTime = DateTime.Parse(model.EndDateTime),
                Rows = model.Rows,
                Page = model.Page,
            };
            var list = dal.QueryByParam1(param);
            var list2 = from o in list
                        select new
                        {
                            GrainId = o.GrainId,
                            GrainName = o.GrainName,
                            GrainCode = o.GrainCode,
                            GrainPinYin = o.GrainPinYin,
                            GrainTypeId = o.GrainTypeId,
                            GrainTypeName = grainTypeFuc(o.GrainTypeId),
                            GrainType2Name = grainType2Fuc(o.GrainType2Id),
                            GrainDescription=o.GrainDescription,
                            GrainColor=o.GrainColor,
                            GrainWeight=o.GrainWeight,
                            GrainUnit=o.GrainUnit,
                            GrainTypeId2=o.GrainType2Id,
                            GrainComment=o.GrainComment,
                        };

            var grid = new
            {
                total = param.Total,
                rows = list2,
            };
            return Json(grid);
        }


        public IActionResult Add()
        {
            var grainTypeDal = new GrainTypeDal();
            var grainType2Dal = new GrainType2Dal();
            var model = new GrainAddModel()
            {
                GrainTypes = grainTypeDal.Query(),
                GrainType2s = grainType2Dal.Query(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(GrainAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new GrainDal();
                var p = mapper.Map<GrainDefinition>(model);
                dal.Add(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
               return Json(new { state = "error", data = ex.Message });
            }

        }

        public IActionResult Update(string GrainId)
        {
            var dal = new GrainDal();
            var grainTypeDal = new GrainTypeDal();
            var grainType2Dal = new GrainType2Dal();
            var p = dal.Find(GrainId);
            var model = mapper.Map<GrainUpdateModel>(p);
            model.GrainTypes = grainTypeDal.Query();
            model.GrainType2s = grainType2Dal.Query();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(GrainUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { state = "error", data = "提交信息验证失败" });
            }

            try
            {
                var dal = new GrainDal();
                var p = dal.Find(model.GrainId);
                mapper.Map(model, p);
                dal.Update(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Delete(string grainId)
        {
            var dal = new GrainDal();
            var p = dal.Find(grainId);
            if (p == null)
            {
                return Json(new { state = "error", data = "找不到这一条数据" });
            }

            try
            {
                dal.Remove(p);
                return Json(new { state = "ok", data = 1 });
            }
            catch (Exception ex)
            {
                return Json(new { state = "error", data = ex.Message });
            }
        }
    }
}