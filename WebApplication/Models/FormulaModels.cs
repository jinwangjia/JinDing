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
    //public class FormulaModels
    //{
    //}

    public class FormulaJsonIndexModel
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


    public class FormulaAddModel
    {
        /// <summary>
        /// 配方名称
        /// </summary>
        [DisplayName("配方名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string FormulaName { get; set; }
        /// <summary>
        /// 配方编码
        /// </summary>
        [DisplayName("配方编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaCode { get; set; }
        /// <summary>
        /// 配方助记码
        /// </summary>
        [DisplayName("配方助记码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaPinYin { get; set; }
    }

    public class FormulaUpdateModel
    {
        /// <summary>
        /// 配方标示
        /// </summary>
        [DisplayName("配方标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaId { get; set; }
        /// <summary>
        /// 配方名称
        /// </summary>
        [DisplayName("配方名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string FormulaName { get; set; }
        /// <summary>
        /// 配方编码
        /// </summary>
        [DisplayName("配方编码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaCode { get; set; }
        /// <summary>
        /// 配方助记码
        /// </summary>
        [DisplayName("配方助记码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FormulaPinYin { get; set; }
        ///// <summary>
        ///// 创建日期
        ///// </summary>
        //[DisplayName("创建日期")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public DateTime CreateDateTime { get; set; }
        ///// <summary>
        ///// 修改日期
        ///// </summary>
        //[DisplayName("修改日期")]
        //[Required(ErrorMessage = "{0}不能为空")]
        //public DateTime UpdateDateTime { get; set; }
    }

    public class FormulaProfile : Profile, IProfile
    {
        public FormulaProfile()
        {
            CreateMap<FormulaAddModel, FormulaDefinition>().BeforeMap((dto, p) =>
            {
                p.FormulaId = Guid.NewGuid().ToString("N");
                p.CreateDateTime = DateTime.Now;
                p.UpdateDateTime = DateTime.Now;
            });

            CreateMap<FormulaDefinition, FormulaUpdateModel>();
            CreateMap<FormulaUpdateModel, FormulaDefinition>().BeforeMap((dto, p) =>
            {
                p.UpdateDateTime = DateTime.Now;
            }); 
            CreateMap<FormulaDefinition, FormulaJsonIndexModel>();
        }
    }

}
