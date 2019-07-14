using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ZkGetOrderModels
    {

    }

    public class ZkGetOrderJsonIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }

        //分页
        public int Page { get; set; }
        //每页行数
        public int Rows { get; set; }

        //总行数(这是一个返回值)
        public int Total { get; set; }
    }

    public class ZkGetOrderAddModel
    {

    }

    public class ZkGetOrderUpdateModel
    {

    }
}
