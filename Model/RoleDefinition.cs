using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Table("Role")]
    public class RoleDefinition
    {
        /// <summary>
        /// 角色标识
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
    }
}
