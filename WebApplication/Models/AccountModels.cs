using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class AccountModel
    {

    }

    public class AccountLogOnModel
    {
        [Required]
        [Display(Name = "账号：")]
        public string Accounts { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码：")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

}