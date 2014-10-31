using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entity;

namespace EF
{
    public class Context : DbContext
    {
        //要创建的数据库表（实体类中必须有ID字段）
        //public DbSet<CustomTable_Main> CustomTable_Main { get; set; }
        public DbSet<Contrast_Organization> Contrast_Organization { get; set; }
        public DbSet<Contrast_UserInfo> Contrast_UserInfo { get; set; }
        public DbSet<User_Organization> User_Organization { get; set; }

        public DbSet<Contrast_Account> Contrast_Account { get; set; }
        public DbSet<Contrast_Workflow> Contrast_Workflow { get; set; }
        public DbSet<Contrast_WorkflowMain> Contrast_WorkflowMain { get; set; }
        public DbSet<Contrast_WorkflowDetail> Contrast_WorkflowDetail { get; set; }
        public DbSet<Contrast_WorkflowMainDetail> Contrast_WorkflowMainDetail { get; set; }

        //数据库生成的其他设置
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Ignore<User_Organization>();
            modelBuilder.Ignore<SessionLoginUser>();
            modelBuilder.Ignore<Contrast_WorkflowMainDetail>();
        }
    }
}
