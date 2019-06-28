using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 班次
    /// </summary>
    [Table("EmployeeGroup")]
    public class EmployeeGroupDefinition
    {
        /// <summary>
        /// 班次标示
        /// </summary>
        [Key,DatabaseGenerated( DatabaseGeneratedOption.Identity)]
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
        /// <summary>
        /// 工控员Id
        /// </summary>
        public string OtherEmployeesId1 { get; set; }
        /// <summary>
        /// 制粒工Id
        /// </summary>
        public string OtherEmployeesId2 { get; set; }
    }
}
