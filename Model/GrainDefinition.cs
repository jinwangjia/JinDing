using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 物料
    /// </summary>
    [Table("Grain")]
    public class GrainDefinition
    {
        /// <summary>
        /// 物料标示
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string GrainId { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string GrainName { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string GrainCode { get; set; }
        /// <summary>
        /// 物料助记码
        /// </summary>
        public string GrainPinYin { get; set; }
        /// <summary>
        /// 物料类别标识
        /// </summary>
        public int GrainTypeId { get; set; }
    }
}
