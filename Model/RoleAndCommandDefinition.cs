using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 角色命令对照表
    /// </summary>
    [Table("RoleAndCommand")]
    public class RoleAndCommandDefinition
    {
        /// <summary>
        /// 角色标识
        /// </summary>
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RoleId { get; set; }

        /// <summary>
        /// 命令标识
        /// </summary>
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CommandId { get; set; }

    }
}
