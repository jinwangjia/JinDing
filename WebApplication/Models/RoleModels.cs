using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Model;

namespace WebApplication.Models
{
    public class RoleIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }
    }

    public class RoleAddModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称：")]
        public string Name { get; set; }
    }

    public class RoleUpdateModel
    {
        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName("角色标识：")]
        public string RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称：")]
        public string Name { get; set; }
    }

    public class RoleSaveModel
    {
        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName("角色标识：")]
        public string RoleId { get; set; }
    }

}