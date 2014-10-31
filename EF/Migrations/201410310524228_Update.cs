namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contrast_WorkflowMain", "Contrast_WorkflowID", c => c.Int());
            CreateIndex("dbo.Contrast_WorkflowMain", "Contrast_WorkflowID");
            AddForeignKey("dbo.Contrast_WorkflowMain", "Contrast_WorkflowID", "dbo.Contrast_Workflow", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contrast_WorkflowMain", "Contrast_WorkflowID", "dbo.Contrast_Workflow");
            DropIndex("dbo.Contrast_WorkflowMain", new[] { "Contrast_WorkflowID" });
            DropColumn("dbo.Contrast_WorkflowMain", "Contrast_WorkflowID");
        }
    }
}
