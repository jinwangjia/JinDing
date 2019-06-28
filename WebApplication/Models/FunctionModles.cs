using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication.Models
{

    public class FunctionUpdateFunctionModel
    {
        public IList<FunctionDefinition> Functions { get; set; }
        public string FunctionId { get; set; }
        public string ParentId { get; set; }
        [Required(ErrorMessage = "该项不能为空")]
        [StringLength(32, ErrorMessage = "不能超过32个字符")]
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Page { get; set; }
        public bool Display { get; set; }
        public int Postion { get; set; }
    }


    public class FunctionIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }

        public IList<FunctionDefinition> Functions { get; set; }
    }

    public class FunctionAddModel
    {
        public IList<FunctionDefinition> Functions { get; set; }
        public IList<string> Pages { get; set; }

        [DisplayName("父功能：")]
        public string ParentId { get; set; }
        [DisplayName("名称：")]
        [Required(ErrorMessage = "该项不能为空")]
        [StringLength(32, ErrorMessage = "不能超过32个字符")]
        public string Name { get; set; }
        [DisplayName("图标：")]
        public string Icon { get; set; }
        [DisplayName("页面：")]
        public string Page { get; set; }
        [DisplayName("显示：")]
        public bool Display { get; set; }
        [DisplayName("顺序：")]
        public int Postion { get; set; }
    }

    public class FunctionUpdateModel
    {
        public IList<FunctionDefinition> Functions { get; set; }
        public IList<string> Pages { get; set; }

        public string FunctionId { get; set; }
        [DisplayName("父功能：")]
        public string ParentId { get; set; }
        [Required(ErrorMessage = "该项不能为空")]
        [StringLength(32, ErrorMessage = "不能超过32个字符")]
        [DisplayName("名称：")]
        public string Name { get; set; }
        [DisplayName("图标：")]
        public string Icon { get; set; }
        [DisplayName("页面：")]
        public string Page { get; set; }
        [DisplayName("显示：")]
        public bool Display { get; set; }
        [DisplayName("顺序：")]
        public int Postion { get; set; }
    }
}