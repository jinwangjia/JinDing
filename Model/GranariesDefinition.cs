using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 仓料对照
    /// </summary>
    [Table("Granaries")]
    public class GranariesDefinition
    {
        /// <summary>
        /// 仓标示
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string GranariesId { get; set; }
        /// <summary>
        /// 仓名称/显示仓号
        /// </summary>
        public string GranariesName { get; set; }
        /// <summary>
        /// 仓序号/顺序仓号
        /// </summary>
        public int GranariesOrder { get; set; }
        /// <summary>
        /// 联动仓标示
        /// </summary>
        public string BrotherGranariesId { get; set; }
        /// <summary>
        /// 最大仓容
        /// </summary>
        public decimal MaxCapacity { get; set; }
        /// <summary>
        /// 实际仓容/当前仓容
        /// </summary>
        public decimal CurrentCapacity { get; set; }
        /// <summary>
        /// 物料标示
        /// </summary>
        public string GrainId { get; set; }
        /// <summary>
        /// 快加提前量（kg）
        /// </summary>
        public int AdvanceWeight1 { get; set; }
        /// <summary>
        /// 慢加提前量（kg）
        /// </summary>
        public int AdvanceWeight2 { get; set; }
        /// <summary>
        /// 脉动提前量（kg）
        /// </summary>
        public int AdvanceWeight3 { get; set; }
        /// <summary>
        /// 快加提前量延时（秒）
        /// </summary>
        public int TimeLength1 { get; set; }
        /// <summary>
        /// 慢加提前量延时（秒）
        /// </summary>
        public int TimeLength2 { get; set; }
        /// <summary>
        /// 脉动提前量延时（秒）
        /// </summary>
        public int TimeLength3 { get; set; }

    }
}
