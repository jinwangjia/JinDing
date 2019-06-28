using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class FrameIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }
        public IList<FunctionDefinition> FunctionList { get; set; }

    }

    public class FrameChangePassword
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名：")]
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [Required]
        [DisplayName("账号：")]
        public string Accounts { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("旧密码：")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("新密码：")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "新密码不一致，请重新输入.")]
        [DisplayName("重复新密码：")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话：")]
        public string Phone { get; set; }
    }
}