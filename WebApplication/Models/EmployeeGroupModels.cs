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
    public class EmployeeGroupModels
    {
    }

    public class EmployeeGroupIndexModel
    {
        //当前用户
        public AdministratorDefinition CurrentAdmin { get; set; }
    }

    public class EmployeeGroupJsonIndexModel
    {
        /// <summary>
        /// 班次标示
        /// </summary>
        public string EmployeeGroupId { get; set; }
        /// <summary>
        /// 班次名称
        /// </summary>
        public string EmployeeGroupName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public int LeftTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public int RightTime { get; set; }
        /// <summary>
        /// 班长Id
        /// </summary>
        public string MonitorId { get; set; }
        public string MonitorName { get; set; }
        /// <summary>
        /// 工控员Id
        /// </summary>
        public string OtherEmployeesId1 { get; set; }
        public string OtherEmployeesName1 { get; set; }
        /// <summary>
        /// 制粒工Id
        /// </summary>
        public string OtherEmployeesId2 { get; set; }
        public string OtherEmployeesName2 { get; set; }
    }

    public class EmployeeGroupAddModel
    {
        /// <summary>
        /// 班次名称
        /// </summary>
        [DisplayName("班次名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string EmployeeGroupName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [DisplayName("开始时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, 23, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int LeftTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DisplayName("结束时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, 23, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int RightTime { get; set; }
        /// <summary>
        /// 班长Id
        /// </summary>
        [DisplayName("班长")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string MonitorId { get; set; }
        /// <summary>
        /// 工控员Id
        /// </summary>
        [DisplayName("工控员")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OtherEmployeesId1 { get; set; }
        /// <summary>
        /// 制粒工Id
        /// </summary>
        [DisplayName("制粒工")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OtherEmployeesId2 { get; set; }

        public IList<AdministratorDefinition> Administrators { get; set; }
    }

    public class EmployeeGroupUpdateModel
    {
        /// <summary>
        /// 班次标示
        /// </summary>
        [DisplayName("班次标示")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string EmployeeGroupId { get; set; }
        /// <summary>
        /// 班次名称
        /// </summary>
        [DisplayName("班次名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}的长度必须大于等于{2}小于等于{1} ")]
        public string EmployeeGroupName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [DisplayName("开始时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, 23, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int LeftTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DisplayName("结束时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(0, 23, ErrorMessage = "{0}的范围是{1}到{2}")]
        public int RightTime { get; set; }
        /// <summary>
        /// 班长Id
        /// </summary>
        [DisplayName("班长")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string MonitorId { get; set; }
        /// <summary>
        /// 工控员Id
        /// </summary>
        [DisplayName("工控员")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OtherEmployeesId1 { get; set; }
        /// <summary>
        /// 制粒工Id
        /// </summary>
        [DisplayName("制粒工")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string OtherEmployeesId2 { get; set; }
        public IList<AdministratorDefinition> Administrators { get; set; }
    }

    public class EmployeeGroupProfile : Profile, IProfile
    {
        public EmployeeGroupProfile()
        {
            CreateMap<EmployeeGroupAddModel, EmployeeGroupDefinition>().BeforeMap((dto, p) =>
            {
                p.EmployeeGroupId = Guid.NewGuid().ToString();
            });

            CreateMap<EmployeeGroupDefinition, EmployeeGroupUpdateModel>();
            CreateMap<EmployeeGroupUpdateModel, EmployeeGroupDefinition>();
            CreateMap<EmployeeGroupDefinition, EmployeeGroupJsonIndexModel>();
        }
    }
}
