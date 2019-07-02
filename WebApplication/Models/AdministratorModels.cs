using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class AdministratorModel
    {
    }

    public class AdministratorIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        public string Accounts { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        public string PassWord { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        public string Phone { get; set; }
    }

    public class AdministratorJsonIndexModel
    {
        /// <summary>
        /// 水管站号
        /// </summary>
        public string StationNo { get; set; }

        //分页
        public int Page { get; set; }
        //每页行数
        public int Rows { get; set; }

    }

    public class AdministratorAddModel
    {
        public IList<RoleDefinition> RoleList { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string Accounts { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string PassWord { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        [RegularExpression(@"(\d{3}-|\d{4}-)?(\d{8}|\d{7})?", ErrorMessage = "手机号不符合要求")]
        public string Phone { get; set; }
        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName("角色")]
        public string RoleId { get; set; }
    }

    public class AdministratorAddSysAdminModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string Accounts { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string PassWord { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        public string Phone { get; set; }
    }

    public class AdministratorUpdateModel
    {
        public IList<RoleDefinition> RoleList { get; set; }
        /// <summary>
        /// 管理员标识
        /// </summary>
        public string AdministratorId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string Accounts { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string PassWord { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName("角色")]
        public string RoleId { get; set; }
    }

    public class AdministratorUpdateSysAdminModel
    {
        /// <summary>
        /// 管理员标识
        /// </summary>
        public string AdministratorId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string Accounts { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{4,39}$", ErrorMessage = "{0}必须字母开头，允许5-40位，允许字母数字下划线")]
        public string PassWord { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName("电话")]
        public string Phone { get; set; }

    }
}