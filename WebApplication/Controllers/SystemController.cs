using Model;
using SqlDal;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /System/

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 重建表列
        /// </summary>
        /// <returns></returns>
        public IActionResult RebuildTableColumn(string name)
        {
            var tableColumnAndAdminDal = new TableColumnAndAdminDal();
            var tableColumnDal = new TableColumnDal();

            //tableColumnAndAdminDal.Clear();
            //tableColumnDal.Clear();


            #region /Device/Index
            if (string.IsNullOrEmpty(name) || name == "Device")
            {
                var currentPage = "/Device/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "StationName", Align = "left", Width = 120, Name = "地区名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "Location", Align = "left", Width = 200, Name = "机井安装地点" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "Longitude", Align = "left", Width = 80, Name = "经度" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "Latitude", Align = "left", Width = 80, Name = "纬度" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "Linkman", Align = "left", Width = 80, Name = "维修管理人" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "Phone", Align = "left", Width = 150, Name = "联系方式" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "Comment", Align = "left", Width = 150, Name = "机井备注" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "CreateDateTime", Align = "center", Width = 140, Name = "登记时间" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "StopFlag", Align = "center", Width = 80, Name = "机井状态" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 13, Field = "AdministratorName", Align = "center", Width = 80, Name = "操作员" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                }
            }
            #endregion

            #region /Administrator/Index
            if (string.IsNullOrEmpty(name) || name == "Administrator")
            {
                var currentPage = "/Administrator/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 00, Field = "BureauName", Align = "left", Width = 100, Name = "水利局" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 01, Field = "StationName", Align = "left", Width = 100, Name = "地区" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "StationNo", Align = "left", Width = 100, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "SysAdmin", Align = "left", Width = 100, Name = "管理员类型" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "Name", Align = "left", Width = 100, Name = "联系人" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "Accounts", Align = "left", Width = 100, Name = "登录账号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "Phone", Align = "left", Width = 100, Name = "电话" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                } 
            }
            #endregion

            #region /DeviceState/Index
            if (string.IsNullOrEmpty(name) || name == "DeviceState")
            {
                var currentPage = "/DeviceState/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "StationName", Align = "left", Width = 120, Name = "地区名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "Location", Align = "left", Width = 200, Name = "机井安装地点" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "UserName", Align = "left", Width = 200, Name = "用户名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "Flow", Align = "right", Width = 110, Name = "流量值(m³/h)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "LineFlag", Align = "center", Width = 70, Name = "水表断线" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "TapFlag", Align = "center", Width = 50, Name = "阀门" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "RelayFlag", Align = "center", Width = 70, Name = "继电器" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "PowerFlag", Align = "center", Width = 70, Name = "供电故障" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 13, Field = "UpdateDateTime", Align = "center", Width = 140, Name = "数据上传时间" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                }
            }
            #endregion

            #region /Log/Index
            if (string.IsNullOrEmpty(name) || name == "Log")
            {
                var currentPage = "/Log/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 00, Field = "Content", Align = "left", Width = 100, Name = "说明" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 01, Field = "AdminName", Align = "left", Width = 100, Name = "操作员名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "BeforeUpdate", Align = "left", Width = 100, Name = "变更前" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "AfterUpdate", Align = "left", Width = 100, Name = "变更后" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "UpdateDateTime", Align = "right", Width = 200, Name = "日期" });

                foreach (var p in tableColumnList)
                {
                    tableColumnDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /PurchaseRecord/Index
            if (string.IsNullOrEmpty(name) || name == "PurchaseRecord")
            {
                var currentPage = "/PurchaseRecord/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var tableColumnList = new List<TableColumnDefinition>();

                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "StationName", Align = "left", Width = 120, Name = "地区名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "Location", Align = "left", Width = 200, Name = "机井安装地点" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "UserName", Align = "left", Width = 200, Name = "用户名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "Comment", Align = "left", Width = 150, Name = "购水备注" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "PurchaseTotalThisTime", Align = "right", Width = 100, Name = "本次购水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "PurchaseAmountThisTime", Align = "right", Width = 80, Name = "购水金额(元)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "PurchaseTotalThisYear", Align = "right", Width = 100, Name = "年度购水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "PurchaseTotal", Align = "right", Width = 100, Name = "累计购水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 13, Field = "TotalSj1", Align = "right", Width = 90, Name = "一级水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 14, Field = "TotalSj2", Align = "right", Width = 90, Name = "二级水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 15, Field = "TotalSj3", Align = "right", Width = 90, Name = "三级水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 16, Field = "PriceSj1", Align = "right", Width = 110, Name = "一级水价(元/m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 17, Field = "PriceSj2", Align = "right", Width = 110, Name = "二级水价(元/m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 18, Field = "PriceSj3", Align = "right", Width = 110, Name = "三级水价(元/m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 19, Field = "AmountSj1", Align = "right", Width = 90, Name = "一级水费(元)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 20, Field = "AmountSj2", Align = "right", Width = 90, Name = "二级水费(元)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 21, Field = "AmountSj3", Align = "right", Width = 90, Name = "三级水费(元)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 22, Field = "PurchaseDateTimeThisTime", Align = "center", Width = 140, Name = "购水时间" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 23, Field = "StopFlag", Align = "center", Width = 80, Name = "用户状态" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 24, Field = "AdministratorName", Align = "center", Width = 80, Name = "操作员" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                }
            }

            #endregion

            #region /User/Index
            if (string.IsNullOrEmpty(name) || name == "User")
            {
                var currentPage = "/User/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "StationName", Align = "left", Width = 120, Name = "地区名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "Location", Align = "left", Width = 200, Name = "机井安装地点" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "UserName", Align = "left", Width = 200, Name = "用户名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "CredentialNo", Align = "left", Width = 150, Name = "证件号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "Linkman", Align = "left", Width = 80, Name = "联系人" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "Phone", Align = "left", Width = 150, Name = "联系方式" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "Comment", Align = "left", Width = 150, Name = "用户备注" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "Overdraft", Align = "right", Width = 90, Name = "透支限量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 13, Field = "AlarmValue", Align = "right", Width = 90, Name = "报警水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 14, Field = "LimitSj1", Align = "right", Width = 110, Name = "一级水价上限(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 15, Field = "LimitSj2", Align = "right", Width = 110, Name = "二级水价上限(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 16, Field = "Sj1", Align = "right", Width = 110, Name = "一级水价(元/m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 17, Field = "Sj2", Align = "right", Width = 110, Name = "二级水价(元/m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 18, Field = "Sj3", Align = "right", Width = 110, Name = "三级水价(元/m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 19, Field = "CreateDateTime", Align = "center", Width = 140, Name = "开户时间" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 20, Field = "StopFlag", Align = "center", Width = 80, Name = "用户状态" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 21, Field = "AdministratorName", Align = "center", Width = 80, Name = "操作员" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                }
            }
            #endregion

            #region /WaterBeUsedDate/Index
            if (string.IsNullOrEmpty(name) || name == "WaterBeUsedDate")
            {
                var currentPage = "/WaterBeUsedDate/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 00, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 01, Field = "StationName", Align = "left", Width = 120, Name = "地区名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "Location", Align = "left", Width = 200, Name = "机井安装地点" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "UserName", Align = "left", Width = 200, Name = "用户名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "PurchaseTotal", Align = "right", Width = 100, Name = "累计购水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "UsedTotal", Align = "right", Width = 100, Name = "累计用水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "Surplus", Align = "right", Width = 90, Name = "剩余水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "Overdraft", Align = "right", Width = 90, Name = "透支限量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "AlarmValue", Align = "right", Width = 90, Name = "报警水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 16, Field = "CreateDateTime", Align = "center", Width = 140, Name = "数据上传时间" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                }
            }
            #endregion

            #region /WaterBeUsedDateFrame/Index
            if (string.IsNullOrEmpty(name) || name == "WaterBeUsedDateFrame")
            {
                var currentPage = "/WaterBeUsedDateFrame/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 00, Field = "Valid", Align = "left", Width = 60, Name = "报文状态" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 01, Field = "Frame", Align = "left", Width = 430, Name = "原始报文" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "GprsNo", Align = "left", Width = 80, Name = "透传模块编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "LineFlag", Align = "center", Width = 70, Name = "水表断线" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "TapFlag", Align = "center", Width = 50, Name = "阀门" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "RelayFlag", Align = "center", Width = 70, Name = "继电器" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "PowerFlag", Align = "center", Width = 70, Name = "供电故障" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "Flow", Align = "right", Width = 110, Name = "流量值(m³/h)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "PurchaseAmount", Align = "right", Width = 100, Name = "累计购水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 13, Field = "UsedAmount", Align = "right", Width = 100, Name = "累计用水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 14, Field = "Surplus", Align = "right", Width = 90, Name = "剩余水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 15, Field = "Overdraft", Align = "right", Width = 90, Name = "透支限量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 16, Field = "AlarmValue", Align = "right", Width = 90, Name = "报警水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 17, Field = "PurchaseDate", Align = "center", Width = 90, Name = "上传购水日期" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 18, Field = "CreateDateTime", Align = "center", Width = 140, Name = "数据上传时间" });

                foreach (var p in tableColumnList)
                {
                    tableColumnDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /WaterBeUsedDateFrameNew/Index
            if (string.IsNullOrEmpty(name) || name == "WaterBeUsedDateFrameNew")
            {
                var currentPage = "/WaterBeUsedDateFrameNew/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 00, Field = "Valid", Align = "left", Width = 60, Name = "报文状态" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 01, Field = "Frame", Align = "left", Width = 430, Name = "原始报文" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "GprsNo", Align = "left", Width = 80, Name = "透传模块编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "LineFlag", Align = "center", Width = 70, Name = "水表断线" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "TapFlag", Align = "center", Width = 50, Name = "阀门" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "RelayFlag", Align = "center", Width = 70, Name = "继电器" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "PowerFlag", Align = "center", Width = 70, Name = "供电故障" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "Flow", Align = "right", Width = 110, Name = "流量值(m³/h)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "PurchaseAmount", Align = "right", Width = 100, Name = "累计购水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 13, Field = "UsedAmount", Align = "right", Width = 100, Name = "累计用水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 14, Field = "Surplus", Align = "right", Width = 90, Name = "剩余水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 15, Field = "Overdraft", Align = "right", Width = 90, Name = "透支限量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 16, Field = "AlarmValue", Align = "right", Width = 90, Name = "报警水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 17, Field = "PurchaseDate", Align = "center", Width = 90, Name = "上传购水日期" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 18, Field = "CreateDateTime", Align = "center", Width = 140, Name = "数据上传时间" });

                foreach (var p in tableColumnList)
                {
                    tableColumnDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /WaterBeUsedDateFrameSaveLong/Index
            if (string.IsNullOrEmpty(name) || name == "WaterBeUsedDateFrameSaveLong")
            {
                var currentPage = "/WaterBeUsedDateFrameSaveLong/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 00, Field = "Valid", Align = "left", Width = 60, Name = "报文状态" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 01, Field = "Frame", Align = "left", Width = 430, Name = "原始报文" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "GprsNo", Align = "left", Width = 80, Name = "透传模块编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "LineFlag", Align = "center", Width = 70, Name = "水表断线" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "TapFlag", Align = "center", Width = 50, Name = "阀门" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "RelayFlag", Align = "center", Width = 70, Name = "继电器" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "PowerFlag", Align = "center", Width = 70, Name = "供电故障" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "Flow", Align = "right", Width = 110, Name = "流量值(m³/h)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "PurchaseAmount", Align = "right", Width = 100, Name = "累计购水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 13, Field = "UsedAmount", Align = "right", Width = 100, Name = "累计用水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 14, Field = "Surplus", Align = "right", Width = 90, Name = "剩余水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 15, Field = "Overdraft", Align = "right", Width = 90, Name = "透支限量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 16, Field = "AlarmValue", Align = "right", Width = 90, Name = "报警水量(m³)" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 17, Field = "PurchaseDate", Align = "center", Width = 90, Name = "上传购水日期" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 18, Field = "CreateDateTime", Align = "center", Width = 140, Name = "数据上传时间" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                }
            }

            #endregion

            #region /CardReplacement/Index
            if (string.IsNullOrEmpty(name) || name == "CardReplacement")
            {
                var currentPage = "/CardReplacement/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var tableColumnList = new List<TableColumnDefinition>();
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 00, Field = "StationNo", Align = "left", Width = 60, Name = "水管站号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 01, Field = "DeviceNo", Align = "left", Width = 80, Name = "机井编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 02, Field = "Location", Align = "left", Width = 200, Name = "机井安装地点" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 03, Field = "UserNo", Align = "left", Width = 90, Name = "用户编号" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 04, Field = "UserName", Align = "left", Width = 200, Name = "用户名称" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 05, Field = "Linkman", Align = "left", Width = 80, Name = "联系人" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 06, Field = "Phone", Align = "left", Width = 150, Name = "联系方式" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 07, Field = "PurchaseTotal", Align = "right", Width = 150, Name = "累计购水量" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 08, Field = "UsedTotal", Align = "right", Width = 150, Name = "累计用水量" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 09, Field = "LastTotal", Align = "right", Width = 150, Name = "剩余水量" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 10, Field = "LastDateTime", Align = "left", Width = 150, Name = "补卡前最后购水时间" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 11, Field = "CreateDateTime", Align = "left", Width = 150, Name = "补卡时间" });
                tableColumnList.Add(new TableColumnDefinition() { TableColumnId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Format = "", Index = 12, Field = "AdministratorName", Align = "center", Width = 80, Name = "操作员" });

                if (!tableColumnDal.HasByFunctionId(function.FunctionId))
                {
                    foreach (var p in tableColumnList)
                    {
                        tableColumnDal.AndOrUpdate(p);
                    }
                }
            }
            #endregion

            return Json("完成");
        }

        public IActionResult RebuildCommand()
        {
            var commandDal = new CommandDal();
            commandDal.Clear();

            #region /Device/Index
            {
                var currentPage = "/Device/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-add", Plain = false, OnClick = "javascript:add()", CommandName = "添加", Index = 1, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-remove", Plain = false, OnClick = "javascript:del()", CommandName = "删除", Index = 2, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-edit", Plain = false, OnClick = "javascript:update()", CommandName = "修改", Index = 3, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-sum", Plain = false, OnClick = "javascript:exportToExcel()", CommandName = "导出Excel", Index = 4, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /Administrator/Index
            {
                var currentPage = "/Administrator/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-add", Plain = false, OnClick = "javascript:addSysAdmin()", CommandName = "添加系统管理员", Index = 1, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-add", Plain = false, OnClick = "javascript:add()", CommandName = "添加管理员", Index = 2, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-remove", Plain = false, OnClick = "javascript:del()", CommandName = "删除", Index = 3, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-edit", Plain = false, OnClick = "javascript:update()", CommandName = "修改", Index = 4, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /DeviceState/Index
            {
                var currentPage = "/DeviceState/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-sum", Plain = false, OnClick = "javascript:exportToExcel()", CommandName = "导出Excel", Index = 1, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /Log/Index
            {
                var currentPage = "/Log/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /PurchaseRecord/Index
            {
                var currentPage = "/PurchaseRecord/Index";
                var function = new FunctionDal().FindByPage(currentPage);


                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-sum", Plain = false, OnClick = "javascript:exportToExcel()", CommandName = "导出Excel", Index = 4, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /Role/Index
            {
                var currentPage = "/Role/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-add", Plain = false, OnClick = "javascript:addRole()", CommandName = "添加", Index = 1, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-remove", Plain = false, OnClick = "javascript:delRole()", CommandName = "删除", Index = 2, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-edit", Plain = false, OnClick = "javascript:updateRole()", CommandName = "修改", Index = 3, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /User/Index
            {
                var currentPage = "/User/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-add", Plain = false, OnClick = "javascript:add()", CommandName = "添加", Index = 1, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-remove", Plain = false, OnClick = "javascript:del()", CommandName = "删除", Index = 2, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-edit", Plain = false, OnClick = "javascript:update()", CommandName = "修改", Index = 3, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-sum", Plain = false, OnClick = "javascript:exportToExcel()", CommandName = "导出Excel", Index = 4, Location = 0 });
                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /WaterBeUsedDate/Index
            {
                var currentPage = "/WaterBeUsedDate/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-sum", Plain = false, OnClick = "javascript:exportToExcel()", CommandName = "导出Excel", Index = 1, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /WaterBeUsedDateFrame/Index
            {
                var currentPage = "/WaterBeUsedDateFrame/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-add", Plain = false, OnClick = "javascript:add()", CommandName = "选中行添加到异常数据表", Index = 1, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-remove", Plain = false, OnClick = "javascript:del()", CommandName = "清空表数据", Index = 2, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-sum", Plain = false, OnClick = "javascript:exportToExcel()", CommandName = "导出Excel", Index = 3, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /WaterBeUsedDateFrameNew/Index
            {
                var currentPage = "/WaterBeUsedDateFrameNew/Index";
                var function = new FunctionDal().FindByPage(currentPage);
                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region /WaterBeUsedDateFrameSaveLong/Index
            {
                var currentPage = "/WaterBeUsedDateFrameSaveLong/Index";
                var function = new FunctionDal().FindByPage(currentPage);

                var commandList2 = new List<CommandDefinition>();
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-display", Plain = false, OnClick = "javascript:tableColumn()", CommandName = "表列", Index = 0, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-remove", Plain = false, OnClick = "javascript:del()", CommandName = "删除选中行", Index = 1, Location = 0 });
                commandList2.Add(new CommandDefinition() { CommandId = Guid.NewGuid().ToString(), FunctionId = function.FunctionId, Href = "#", Class = "easyui-linkbutton", IconCls = "icon-remove", Plain = false, OnClick = "javascript:TruncateTable()", CommandName = "清空表数据", Index = 2, Location = 0 });

                foreach (var p in commandList2)
                {
                    commandDal.AndOrUpdate(p);
                }
            }
            #endregion

            #region MyRegion
            {


            }
            #endregion

            return Json("完成");
        }

    }
}
