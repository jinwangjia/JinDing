using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Command")]
    public class CommandDefinition
    {
        /// <summary>
        /// 命令标识
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CommandId { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        public string FunctionId { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string IconCls { get; set; }
        /// <summary>
        /// 未知
        /// </summary>
        public bool Plain { get; set; }
        /// <summary>
        /// 动作
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string CommandName { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public int Location { get; set; }
    }
}
