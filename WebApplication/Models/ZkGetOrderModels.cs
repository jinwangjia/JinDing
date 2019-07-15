using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SqlDal;

namespace WebApplication.Models
{
    public class ZkGetOrderModels
    {

    }

    public class ZkGetOrderJsonIndexParamModel
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

    public class ZkGetOrderJsonIndexItemModel
    {
        /// <summary>
        /// 工单号
        /// </summary>
        public string ZkGetOrderId { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public int Batch { get; set; }
        /// <summary>
        /// 是否为公共配方
        /// </summary>
        public string IsPublic { get; set; }
        /// <summary>
        /// 配方标示
        /// </summary>
        public string FormulaId { get; set; }
        /// <summary>
        /// 配方编码
        /// </summary>
        public string FormulaCode { get; set; }
        /// <summary>
        /// 工单开始日期
        /// </summary>
        public string ManufacturingDate { get; set; }
        /// <summary>
        /// 工单结束日期
        /// </summary>
        public string CancelDate { get; set; }
        /// <summary>
        /// 工单重量
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 工单类型
        /// </summary>
        public string OrderType { get; set; }
    }

    public class ZkGetOrderAddModel
    {
        public IList<FormulaDefinition> FormulaList { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        [DisplayName("批次号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 10000, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int Batch { get; set; }
        /// <summary>
        /// 是否为公共配方
        /// </summary>
        [DisplayName("是否为公共配方")]
        //[Required(ErrorMessage = "{0}不能为空")]
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
        //[Required(ErrorMessage = "{0}不能为空")]
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
        public IList<FormulaDefinition> FormulaList { get; set; }

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
        [Range(1, 10000, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int Batch { get; set; }
        /// <summary>
        /// 是否为公共配方
        /// </summary>
        [DisplayName("是否为公共配方")]
        //[Required(ErrorMessage = "{0}不能为空")]
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
        //[Required(ErrorMessage = "{0}不能为空")]
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


    public class ZkGetOrderProfile : Profile, IProfile
    {
        public ZkGetOrderProfile()
        {
            CreateMap<ZkGetOrderAddModel, ZkGetOrderDefinition>().AfterMap((dto, p) =>
            {
                p.ZkGetOrderId = Guid.NewGuid().ToString("N");
            });
            CreateMap<ZkGetOrderDefinition, ZkGetOrderUpdateModel>();
            CreateMap<ZkGetOrderUpdateModel, ZkGetOrderDefinition>();
            CreateMap<ZkGetOrderDefinition, ZkGetOrderJsonIndexItemModel>().AfterMap((p, dto) =>
            {
                dto.IsPublic = p.IsPublic ? "是" : "否";
                dto.ManufacturingDate = p.ManufacturingDate.ToString("yyyy-MM-dd");
                dto.CancelDate = p.CancelDate == null ? "" : p.CancelDate.ToString("yyyy-MM-dd");
                if (p.OrderType == 1)
                    dto.OrderType = "本地自建";
                if (p.OrderType == 2)
                    dto.OrderType = "ERP同步";
            });
            CreateMap<ZkGetOrderJsonIndexParamModel,ZkGetOrderDal.QueryByParamIn >(); 

        }
    }

}
