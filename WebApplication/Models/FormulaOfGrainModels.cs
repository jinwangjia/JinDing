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
    //public class FormulaOfGrainModels
    //{
    //}

    public class FormulaOfGrainAddModel
    {
        /// <summary>
        /// 配方标示
        /// </summary>
        [DisplayName("配方标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaId { get; set; }
        /// <summary>
        /// 物料标示
        /// </summary>
        [DisplayName("物料标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainId { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        [DisplayName("重量")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 物料类别标识
        /// </summary>
        [DisplayName("物料类别标识")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GrainTypeId { get; set; }

        public IList<GrainDefinition> Grains { get; set; }
    }
    public class FormulaOfGrainUpdateModel
    {
        /// <summary>
        /// 配方标示
        /// </summary>
        [DisplayName("配方标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaId { get; set; }
        /// <summary>
        /// 物料标示
        /// </summary>
        [DisplayName("物料标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string GrainId { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        [DisplayName("物料名称")]
        public string GrainName { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        [DisplayName("重量")]
        [Required(ErrorMessage = "{0}不能为空")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 物料类别标识
        /// </summary>
        [DisplayName("物料类别标识")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int GrainTypeId { get; set; }


    }


    public class FormulaOfGrainProfile : Profile, IProfile
    {
        public FormulaOfGrainProfile()
        {
            CreateMap<FormulaOfGrainAddModel, FormulaOfGrainDefinition>();
            CreateMap<FormulaOfGrainDefinition, FormulaOfGrainUpdateModel>();
            CreateMap<FormulaOfGrainUpdateModel, FormulaOfGrainDefinition>();
        }
    }
}
