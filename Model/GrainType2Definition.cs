using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    /// <summary>
    /// 物料分类
    /// </summary>
    [Table("GrainType2")]
    public class GrainType2Definition
    {
        /// <summary>
        /// 物料分类标识
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GrainType2Id { get; set; }
        /// <summary>
        /// 物料分类名称
        /// </summary>
        public string GrainType2Name { get; set; }
    }
}
