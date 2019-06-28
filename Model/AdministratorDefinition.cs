using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Administrator")]
    public class AdministratorDefinition
    {
        /// <summary>
        /// 管理员标识
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AdministratorId { get; set; }
        /// <summary>
        /// 是否为系统管理员
        /// </summary>
        public bool SysAdmin { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string Accounts { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 重置密码
        /// </summary>
        public bool ReWritePassWord { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 角色标识
        /// </summary>
        public string RoleId { get; set; }
    }
}
