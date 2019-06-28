using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    /// <summary>
    /// 分部视图的数据模型
    /// </summary>
    public class PartialModels
    {
    }
    /// <summary>
    /// 显示表字段的数据模型
    /// </summary>
    public class PartialTableColumnModel
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        public string FunctionId { get; set; }
        /// <summary>
        /// 当前管理员
        /// </summary>
        public AdministratorDefinition CurrentAdmin { get; set; }
    }

    public class PartialTableCommandModel
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        public string FunctionId { get; set; }
        /// <summary>
        /// 当前管理员
        /// </summary>
        public AdministratorDefinition CurrentAdmin { get; set; }
    }
}
