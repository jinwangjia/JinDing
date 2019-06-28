using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 功能表
    /// </summary>
    [Table("Function")]
    public class FunctionDefinition
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FunctionId { get; set; }

        /// <summary>
        /// 父功能编号
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 页面地址
        /// </summary>
        public string Page { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Display { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public int Postion { get; set; }


    }
}
