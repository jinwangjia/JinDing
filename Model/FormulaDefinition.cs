using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 配方
    /// </summary>
    [Table("Formula")]
    public class FormulaDefinition
    {
        /// <summary>
        /// 配方标示
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FormulaId { get; set; }
        /// <summary>
        /// 配方名称
        /// </summary>
        public string FormulaName { get; set; }
        /// <summary>
        /// 配方编码
        /// </summary>
        public string FormulaCode { get; set; }
        /// <summary>
        /// 配方助记码
        /// </summary>
        public string FormulaPinYin { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDateTime { get; set; }
    }
}
