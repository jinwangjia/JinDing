using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    /// <summary>
    /// 工单表
    /// </summary>
    [Table("ZkGetOrder")]
    public class ZkGetOrderDefinition
    {
        /// <summary>
        /// 工单号
        /// </summary>
        [Key,DatabaseGenerated( DatabaseGeneratedOption.None)]
        public string ZkGetOrderId { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public int Batch { get; set; }
        /// <summary>
        /// 是否为公共配方
        /// </summary>
        public bool IsPublic { get; set; }
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
        public DateTime ManufacturingDate { get; set; }
        /// <summary>
        /// 工单结束日期
        /// </summary>
        public DateTime CancelDate { get; set; }
        /// <summary>
        /// 工单重量
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 工单类型
        /// </summary>
        public int OrderType { get; set; }
    }
}
