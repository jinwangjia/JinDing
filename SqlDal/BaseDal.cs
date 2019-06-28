using Microsoft.EntityFrameworkCore;
using Model;

namespace SqlDal
{
    public class BaseDal : DbContext
    {
        public DbSet<ConfigDefinition> Config { get; set; }
        /// <summary>
        /// 角色功能对照表
        /// </summary>
        public DbSet<RoleAndFunctionDefinition> RoleAndFunction { get; set; }
        /// <summary>
        /// 功能表
        /// </summary>
        public DbSet<FunctionDefinition> Function { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<RoleDefinition> Role { get; set; }

        public DbSet<CommandDefinition> Command { get; set; }

        public DbSet<RoleAndCommandDefinition> RoleAndCommand { get; set; }

        public DbSet<AdministratorDefinition> Administrator { get; set; }

        public DbSet<TableColumnDefinition> TableColumn { get; set; }

        public DbSet<TableColumnAndAdminDefinition> TableColumnAndAdmin { get; set; }
        /// <summary>
        /// 人员日志
        /// </summary>
        public DbSet<LogDefinition> Log { get; set; }
        /// <summary>
        /// 班次
        /// </summary>
        public DbSet<EmployeeGroupDefinition> EmployeeGroup { get; set; }
        /// <summary>
        /// 设备日志
        /// </summary>
        public DbSet<DeviceLogDefinition> DeviceLog { get; set; }
        /// <summary>
        /// 操作日志
        /// </summary>
        public DbSet<DataChangeLogDefinition> DataChangeLog { get; set; }
        /// <summary>
        /// 设备表
        /// </summary>
        public DbSet<DeviceDefinition> Device { get; set; }
        /// <summary>
        /// 配方
        /// </summary>
        public DbSet<FormulaDefinition> Formula { get; set; }
        /// <summary>
        /// 仓料对照
        /// </summary>
        public DbSet<GranariesDefinition> Granaries { get; set; }
        /// <summary>
        /// 物料
        /// </summary>
        public DbSet<GrainDefinition> Grain { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=JinDing;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleAndCommandDefinition>().HasKey(o => new { o.RoleId, o.CommandId });
            modelBuilder.Entity<RoleAndFunctionDefinition>().HasKey(o => new { o.RoleId, o.FunctionId });
            modelBuilder.Entity<TableColumnAndAdminDefinition>().HasKey(o => new { o.AdministratorId, o.FunctionId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
