using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ZkGetOrderModels
    {

    }

    public class ZkGetOrderJsonIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }

        //分页
        public int Page { get; set; }
        //每页行数
        public int Rows { get; set; }

        //总行数(这是一个返回值)
        public int Total { get; set; }
    }

    public class ZkGetOrderAddModel
    {
        /// <summary>
        /// 批次号
        /// </summary>
        [DisplayName("批次号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Batch { get; set; }
        /// <summary>
        /// 是否为公共配方
        /// </summary>
        [DisplayName("是否为公共配方")]
        [Required(ErrorMessage = "{0}不能为空")]
        public bool IsPublic { get; set; }
        /// <summary>
        /// 配方标示
        /// </summary>
        [DisplayName("配方标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaId { get; set; }
        /// <summary>
        /// 配方编码
        /// </summary>
        [DisplayName("配方编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaCode { get; set; }
        /// <summary>
        /// 工单开始日期
        /// </summary>
        [DisplayName("工单开始日期")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ManufacturingDate { get; set; }
        /// <summary>
        /// 工单结束日期
        /// </summary>
        [DisplayName("工单结束日期")]
        public DateTime CancelDate { get; set; }
        /// <summary>
        /// 工单重量
        /// </summary>
        [DisplayName("工单重量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 10000, ErrorMessage = "{0}的范围是{1}到{2}")]
        public decimal Weight { get; set; }
        /// <summary>
        /// 工单类型
        /// </summary>
        [DisplayName("工单类型")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int OrderType { get; set; }
    }

    public class ZkGetOrderUpdateModel
    {
        /// <summary>
        /// 工单号
        /// </summary>
        [DisplayName("工单号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ZkGetOrderId { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        [DisplayName("批次号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Batch { get; set; }
        /// <summary>
        /// 是否为公共配方
        /// </summary>
        [DisplayName("是否为公共配方")]
        [Required(ErrorMessage = "{0}不能为空")]
        public bool IsPublic { get; set; }
        /// <summary>
        /// 配方标示
        /// </summary>
        [DisplayName("配方标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaId { get; set; }
        /// <summary>
        /// 配方编码
        /// </summary>
        [DisplayName("配方编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaCode { get; set; }
        /// <summary>
        /// 工单开始日期
        /// </summary>
        [DisplayName("工单开始日期")]
        [Required(ErrorMessage = "{0}不能为空")]
        public DateTime ManufacturingDate { get; set; }
        /// <summary>
        /// 工单结束日期
        /// </summary>
        [DisplayName("工单结束日期")]
        public DateTime CancelDate { get; set; }
        /// <summary>
        /// 工单重量
        /// </summary>
        [DisplayName("工单重量")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 10000, ErrorMessage = "{0}的范围是{1}到{2}")]
        public decimal Weight { get; set; }
        /// <summary>
        /// 工单类型
        /// </summary>
        [DisplayName("工单类型")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int OrderType { get; set; }
    }
}
