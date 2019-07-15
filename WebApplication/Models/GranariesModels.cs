using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    //public class GranariesModels
    //{
    //}

    public class GranariesJsonIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }
        //[DisplayName("发生时间：")]
        //public String BeginDateTime { get; set; }
        //[DisplayName("发生时间：")]
        //public String EndDateTime { get; set; }

        //分页
        public int Page { get; set; }
        //每页行数
        public int Rows { get; set; }

        //总行数(这是一个返回值)
        public int Total { get; set; }
    }

    public class GranariesAddModel
    {
        /// <summary>
        /// 仓名称/显示仓号
        /// </summary>
        [DisplayName("仓名称/显示仓号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string GranariesName { get; set; }
        /// <summary>
        /// 仓序号/顺序仓号
        /// </summary>
        [DisplayName("仓序号/顺序仓号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 40, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int GranariesOrder { get; set; }
        /// <summary>
        /// 最大仓容
        /// </summary>
        [DisplayName("最大仓容")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, uint.MaxValue, ErrorMessage = "{0}的范围是{1}到{2}")]
        public decimal MaxCapacity { get; set; }
    }

    public class GranariesUpdateModel
    {
        /// <summary>
        /// 仓标示
        /// </summary>
        [DisplayName("仓标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GranariesId { get; set; }
        /// <summary>
        /// 仓名称/显示仓号
        /// </summary>
        [DisplayName("仓名称/显示仓号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string GranariesName { get; set; }
        /// <summary>
        /// 仓序号/顺序仓号
        /// </summary>
        [DisplayName("仓序号/顺序仓号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 40, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int GranariesOrder { get; set; }
        ///// <summary>
        ///// 联动仓标示
        ///// </summary>
        //[DisplayName("联动仓标示")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string BrotherGranariesId { get; set; }
        /// <summary>
        /// 最大仓容
        /// </summary>
        [DisplayName("最大仓容")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, uint.MaxValue, ErrorMessage = "{0}的范围是{1}到{2}")]
        public decimal MaxCapacity { get; set; }
        ///// <summary>
        ///// 实际仓容/当前仓容
        ///// </summary>
        //[DisplayName("实际仓容/当前仓容")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public decimal CurrentCapacity { get; set; }
        ///// <summary>
        ///// 物料标示
        ///// </summary>
        //[DisplayName("物料标示")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public string GrainId { get; set; }
        ///// <summary>
        ///// 快加提前量（kg）
        ///// </summary>
        //[DisplayName("快加提前量（kg）")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int AdvanceWeight1 { get; set; }
        ///// <summary>
        ///// 慢加提前量（kg）
        ///// </summary>
        //[DisplayName("慢加提前量（kg）")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int AdvanceWeight2 { get; set; }
        ///// <summary>
        ///// 脉动提前量（kg）
        ///// </summary>
        //[DisplayName("脉动提前量（kg）")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int AdvanceWeight3 { get; set; }
        ///// <summary>
        ///// 快加提前量延时（秒）
        ///// </summary>
        //[DisplayName("快加提前量延时（秒）")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int TimeLength1 { get; set; }
        ///// <summary>
        ///// 慢加提前量延时（秒）
        ///// </summary>
        //[DisplayName("慢加提前量延时（秒）")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int TimeLength2 { get; set; }
        ///// <summary>
        ///// 脉动提前量延时（秒）
        ///// </summary>
        //[DisplayName("脉动提前量延时（秒）")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public int TimeLength3 { get; set; }
    }

    public class GranariesProfile : Profile, IProfile
    {
        public GranariesProfile()
        {
            CreateMap<GranariesAddModel, GranariesDefinition>().AfterMap((dto, p) =>
            {
                p.GranariesId = Guid.NewGuid().ToString("N");
            });

            CreateMap<GranariesDefinition, GranariesUpdateModel>();
            CreateMap<GranariesUpdateModel, GranariesDefinition>();
            CreateMap<GranariesDefinition, GranariesJsonIndexModel>();
        }
    }
}
