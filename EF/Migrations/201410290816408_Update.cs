namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contrast_Workflow", new[] { "Contrast_AccountID" });
            AddColumn("dbo.Contrast_Workflow", "IsSelfCheck", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Contrast_Workflow", "Contrast_AccountID", c => c.Int());
            CreateIndex("dbo.Contrast_Workflow", "Contrast_AccountID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contrast_Workflow", new[] { "Contrast_AccountID" });
            AlterColumn("dbo.Contrast_Workflow", "Contrast_AccountID", c => c.Int(nullable: false));
            DropColumn("dbo.Contrast_Workflow", "IsSelfCheck");
            CreateIndex("dbo.Contrast_Workflow", "Contrast_AccountID");
        }
    }
}
