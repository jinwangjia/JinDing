using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    /// <summary>
    /// 设备日志
    /// </summary>
    [Table("DeviceLog")]
    public class DeviceLogDefinition
    {
        /// <summary>
        /// 设备日志标识
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DeviceLogId { get; set; }
        /// <summary>
        /// 设备标识
        /// </summary>
        public string DeviceId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime UpdateDateTime { get; set; }
    }
}
