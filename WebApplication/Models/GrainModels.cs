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
    //public class GrainModels
    //{
    //}

    public class GrainJsonIndexModel
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

    public class GrainAddModel
    {
        /// <summary>
        /// 物料标示/物料PK
        /// </summary>
        [DisplayName("物料标示/物料PK")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainId { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        [DisplayName("物料名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string GrainName { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        [DisplayName("物料编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainCode { get; set; }
        /// <summary>
        /// 物料助记码
        /// </summary>
        [DisplayName("物料助记码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainPinYin { get; set; }

        /// <summary>
        /// 物料类别标识
        /// </summary>
        [DisplayName("物料类别标识")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GrainTypeId { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        [DisplayName("物料描述")]
        public string GrainDescription { get; set; }
        /// <summary>
        /// 物料颜色
        /// </summary>
        [DisplayName("物料颜色")]
        public string GrainColor { get; set; }
        /// <summary>
        /// 物料重量
        /// </summary>
        [DisplayName("物料重量")]
        public decimal GrainWeight { get; set; }
        /// <summary>
        /// 物料单位
        /// </summary>
        [DisplayName("物料单位")]
        public string GrainUnit { get; set; }
        /// <summary>
        /// 物料分类(产品半成品袋皮预混料等)
        /// </summary>
        [DisplayName("物料分类")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GrainType2Id { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string GrainComment { get; set; }

        public IList<GrainTypeDefinition> GrainTypes { get; set; }
        public IList<GrainType2Definition> GrainType2s { get; set; }
    }

    public class GrainUpdateModel
    {
        /// <summary>
        /// 物料标示/物料PK
        /// </summary>
        [DisplayName("物料标示/物料PK")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainId { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        [DisplayName("物料名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string GrainName { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        [DisplayName("物料编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainCode { get; set; }
        /// <summary>
        /// 物料助记码
        /// </summary>
        [DisplayName("物料助记码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainPinYin { get; set; }
        /// <summary>
        /// 物料类别标识
        /// </summary>
        [DisplayName("物料类别标识")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GrainTypeId { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        [DisplayName("物料描述")]
        public string GrainDescription { get; set; }
        /// <summary>
        /// 物料颜色
        /// </summary>
        [DisplayName("物料颜色")]
        public string GrainColor { get; set; }
        /// <summary>
        /// 物料重量
        /// </summary>
        [DisplayName("物料重量")]
        public decimal GrainWeight { get; set; }
        /// <summary>
        /// 物料单位
        /// </summary>
        [DisplayName("物料单位")]
        public string GrainUnit { get; set; }
        /// <summary>
        /// 物料分类(产品半成品袋皮预混料等)
        /// </summary>
        [DisplayName("物料分类")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GrainType2Id { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string GrainComment { get; set; }

        public IList<GrainTypeDefinition> GrainTypes { get; set; }
        public IList<GrainType2Definition> GrainType2s { get; set; }

    }

    public class GrainProfile : Profile, IProfile
    {
        public GrainProfile()
        {
            CreateMap<GrainAddModel, GrainDefinition>();
            CreateMap<GrainDefinition, GrainUpdateModel>();
            CreateMap<GrainUpdateModel, GrainDefinition>();
            CreateMap<GrainDefinition, GrainJsonIndexModel>();
        }


    }

}
