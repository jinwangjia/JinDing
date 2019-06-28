using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 表列用户对照表
    /// </summary>
    [Table("TableColumnAndAdmin")]
    public class TableColumnAndAdminDefinition
    {
        /// <summary>
        /// 管理员标识
        /// </summary>
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AdministratorId { get; set; }
        /// <summary>
        /// 表列标识
        /// </summary>
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TableColumnId { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        public string FunctionId { get; set; }

    }
}
