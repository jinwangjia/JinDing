using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    //public class DeviceModels
    //{
    //}

    public class DeviceJsonIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }
        //[DisplayName("发生时间：")]
        //public String BeginDateTime { get; set; }
        //[DisplayName("发生时间：")]
        //public String EndDateTime { get; set; }

        //分页
        public int Page { get; set; }
        //每页行数
        public int Rows { get; set; }

        //总行数(这是一个返回值)
        public int Total { get; set; }
    }

    public class DeviceAddModel
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        [DisplayName("设备名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string DeviceName { get; set; }
    }

    public class DeviceUpdateModel
    {
        /// <summary>
        /// 设备标识
        /// </summary>
        [DisplayName("设备标识")]
        [Required(ErrorMessage = "{0}不能为空")]
        public long DeviceId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        [DisplayName("设备名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string DeviceName { get; set; }
    }

    public class DeviceProfile : Profile, IProfile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceAddModel, DeviceDefinition>();
            CreateMap<DeviceDefinition, DeviceUpdateModel>();
            CreateMap<DeviceUpdateModel, DeviceDefinition>();
            CreateMap<DeviceDefinition, DeviceJsonIndexModel>();
        }
    }
}
