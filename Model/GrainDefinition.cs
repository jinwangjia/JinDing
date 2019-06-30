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
        /// 物料标示/物料PK
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
        /// 物料类别标识(大料，小料，油脂，回机料)
        /// </summary>
        public int GrainTypeId { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string GrainDescription { get; set; }
        /// <summary>
        /// 物料颜色
        /// </summary>
        public string GrainColor { get; set; }
        /// <summary>
        /// 物料重量
        /// </summary>
        public decimal GrainWeight { get; set; }
        /// <summary>
        /// 物料单位
        /// </summary>
        public string GrainUnit { get; set; }
        /// <summary>
        /// 物料分类(产品半成品袋皮预混料等)
        /// </summary>
        public int GrainType2Id { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string GrainComment { get; set; }
    }
}
