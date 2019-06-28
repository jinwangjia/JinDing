using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 人员日志
    /// </summary>
    [Table("Log")]
    public class LogDefinition
    {
        [Key,DatabaseGenerated( DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; }
        public string Content { get; set; }
        public string AdminName { get; set; }
        public string BeforeUpdate { get; set; }
        public string AfterUpdate { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
