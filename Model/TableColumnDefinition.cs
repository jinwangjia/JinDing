using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 表列
    /// </summary>
    [Table("TableColumn")]
    public class TableColumnDefinition
    {
        /// <summary>
        /// 表列标识
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TableColumnId { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        public string FunctionId { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// 字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        public string Align { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Index { get; set; }
    }
}
