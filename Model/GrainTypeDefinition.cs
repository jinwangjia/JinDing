using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    /// <summary>
    /// 物料类别
    /// </summary>
    [Table("GrainType")]
    public class GrainTypeDefinition
    {
        /// <summary>
        /// 物料类别标识
        /// </summary>
        [Key,DatabaseGenerated( DatabaseGeneratedOption.None)]
        public int GrainTypeId { get; set; }
        /// <summary>
        /// 物料类别名称
        /// </summary>
        public string GrainTypeName { get; set; }
    }
}
