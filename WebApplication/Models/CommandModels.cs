using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class CommandModel
    {

    }

    public class CommandIndexModel
    {

    }

    public class CommandIndexJsonModel
    {

    }

    public class CommandAddModel
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string FunctionId { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [DisplayName("链接")]
        public string Href { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        [DisplayName("样式")]
        public string Class { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [DisplayName("图标")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string IconCls { get; set; }
        /// <summary>
        /// 未知
        /// </summary>
        [DisplayName("未知")]
        public bool Plain { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        [DisplayName("动作")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OnClick { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CommandName { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        [DisplayName("顺序")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Index { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        [DisplayName("位置")]
        public int Location { get; set; }
    }

    public class CommandUpdateModel
    {
        [Required(ErrorMessage = "{0}不能为空")]
        public string CommandId { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        public string FunctionId { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [DisplayName("链接")]
        public string Href { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        [DisplayName("样式")]
        public string Class { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [DisplayName("图标")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string IconCls { get; set; }
        /// <summary>
        /// 未知
        /// </summary>
        [DisplayName("未知")]
        public bool Plain { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        [DisplayName("动作")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OnClick { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        [DisplayName("名称")]
        public string CommandName { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        [DisplayName("顺序")]
        [Required(ErrorMessage = "{0}不能为空")]
        public int Index { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        [DisplayName("位置")]
        public int Location { get; set; }
    }

}