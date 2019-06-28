using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Table("DataChangeLog")]
    public class DataChangeLogDefinition
    {
        /// <summary>
        /// 操作日志标识
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DataChangeLogId { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 操作员名称
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 变更前
        /// </summary>
        public string BeforeUpdate { get; set; }
        /// <summary>
        /// 变更后
        /// </summary>
        public string AfterUpdate { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime UpdateDateTime { get; set; }
    }
}
