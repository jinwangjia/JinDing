using Model;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class HomeModels
    {
    }

    public class HomeIndexModel
    {
        public int Count { get; set; }
    }

    public class HomeModelDesktop
    {
        /// <summary>
        /// 登记用户数
        /// </summary>
        public int UserCount { get; set; }

        /// <summary>
        /// 登记机井数
        /// </summary>
        public int DeviceCount { get; set; }

        /// <summary>
        /// 在线机井数
        /// </summary>
        public int DeviceCountOfOnLine { get; set; }

        /// <summary>
        /// 故障机井数
        /// </summary>
        public int DeviceCountOfPowerFlag { get; set; }


        public IList<LogDefinition> Log { get; set; }
    }

    public class HomeModelTopInfo
    {
        public AdministratorDefinition CurrentAdmin { get; set; }
    }


    public class HomeSetThemesModel
    {
        public string Theme { get; set; }
    }
}
