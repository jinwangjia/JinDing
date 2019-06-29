using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 配方之物料表
    /// </summary>
    [Table("FormulaOfGrain")]
    public class FormulaOfGrainDefinition
    {
        /// <summary>
        /// 配方标示
        /// </summary>
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FormulaId { get; set; }
        /// <summary>
        /// 物料标示
        /// </summary>
        public string GrainId { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal Amount { get; set; }
    }
}
