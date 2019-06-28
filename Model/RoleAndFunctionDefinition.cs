using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 角色功能对照表
    /// </summary>
    [Table("RoleAndFunction")]
    public class RoleAndFunctionDefinition
    {
        /// <summary>
        /// 角色标识
        /// </summary>
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None),Column( Order = 0 )]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RoleId { get; set; }

        /// <summary>
        /// 功能编号
        /// </summary>
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None),Column( Order = 1 )]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FunctionId { get; set; }
    }
}
