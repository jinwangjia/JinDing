using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class TableColumnModels
    {

    }

    public class TableColumnAndModel
    {
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 表列标识
        /// </summary>
        [DisplayName("表列标识")]
        public string TableColumnId { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        [DisplayName("功能编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FunctionId { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [DisplayName("是否显示")]
        public bool Visible { get; set; }
        /// <summary>
        /// 字段
        /// </summary>
        [DisplayName("字段")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Field { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        [DisplayName("对齐方式")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Align { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [DisplayName("宽度")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 500,ErrorMessage="{0}的范围是{1}到{2}")]
        public int Width { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Name { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        [DisplayName("样式")]
        public string Format { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("序号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, 100, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int Index { get; set; }
    }

    public class TableColumnUpdateModel
    {
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 表列标识
        /// </summary>
        [DisplayName("表列标识")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string TableColumnId { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        [DisplayName("功能编号")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string FunctionId { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [DisplayName("是否显示")]
        public bool Visible { get; set; }
        /// <summary>
        /// 字段
        /// </summary>
        [DisplayName("字段")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Field { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        [DisplayName("对齐方式")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Align { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [DisplayName("宽度")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 500, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int Width { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Name { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        [DisplayName("样式")]
        public string Format { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("序号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, 100, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int Index { get; set; }
    }

    public class TableColumnIndexModel
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        public AdministratorDefinition CurrentAdmin { get; set; }
        public string FunctionId { get; set; }
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
    }

    public class TableColumnIndexAdminModel
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        public AdministratorDefinition CurrentAdmin { get; set; }
        public string FunctionId { get; set; }
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
    }

    public class TableColumnJsonIndexModel
    {

    }

    public class TableColumnSaveModel
    {
        public string FunctionId { get; set; }
    }


    public class TableColumnRebuildModel
    {
        public string FunctionId { get; set; }
    }
}