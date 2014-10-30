namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contrast_Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contrast_WorkflowMain",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contrast_AccountID = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        Contrast_OrganizationID = c.Int(nullable: false),
                        Contrast_UserInfoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contrast_Account", t => t.Contrast_AccountID)
                .ForeignKey("dbo.Contrast_Organization", t => t.Contrast_OrganizationID)
                .ForeignKey("dbo.Contrast_UserInfo", t => t.Contrast_UserInfoID)
                .Index(t => t.Contrast_AccountID)
                .Index(t => t.Contrast_OrganizationID)
                .Index(t => t.Contrast_UserInfoID);
            
            CreateTable(
                "dbo.Contrast_Organization",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Qualifications = c.String(),
                        Location = c.String(),
                        Credit = c.String(),
                        LegalPerson = c.String(),
                        Guarantee = c.String(),
                        ProvideMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BeginMonth = c.Int(nullable: false),
                        EndMonth = c.Int(nullable: false),
                        DemandInterest = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contrast_UserInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Privacies = c.Boolean(nullable: false),
                        LegalPerson = c.String(),
                        CompanyName = c.String(),
                        DemandMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DemandMonth = c.Int(nullable: false),
                        AcceptInterest = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contrast_WorkflowDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contrast_WorkflowMainID = c.Int(nullable: false),
                        Contrast_WorkflowID = c.Int(nullable: false),
                        Contrast_AccountID = c.Int(),
                        CheckTime = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contrast_Account", t => t.Contrast_AccountID)
                .ForeignKey("dbo.Contrast_Workflow", t => t.Contrast_WorkflowID)
                .ForeignKey("dbo.Contrast_WorkflowMain", t => t.Contrast_WorkflowMainID)
                .Index(t => t.Contrast_WorkflowMainID)
                .Index(t => t.Contrast_WorkflowID)
                .Index(t => t.Contrast_AccountID);
            
            CreateTable(
                "dbo.Contrast_Workflow",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Sort = c.Int(nullable: false),
                        Contrast_AccountID = c.Int(),
                        IsSelfCheck = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contrast_Account", t => t.Contrast_AccountID)
                .Index(t => t.Contrast_AccountID);

            var migrationDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\");

            string scriptText = System.IO.File.ReadAllText(System.IO.Path.Combine(migrationDir, "Initial.sql"));
            var commandTexts = scriptText.Split(new string[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var commandText in commandTexts)
            {
                if (!String.IsNullOrWhiteSpace(commandText))
                    Sql(commandText);
            }
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contrast_WorkflowDetail", "Contrast_WorkflowMainID", "dbo.Contrast_WorkflowMain");
            DropForeignKey("dbo.Contrast_WorkflowDetail", "Contrast_WorkflowID", "dbo.Contrast_Workflow");
            DropForeignKey("dbo.Contrast_Workflow", "Contrast_AccountID", "dbo.Contrast_Account");
            DropForeignKey("dbo.Contrast_WorkflowDetail", "Contrast_AccountID", "dbo.Contrast_Account");
            DropForeignKey("dbo.Contrast_WorkflowMain", "Contrast_UserInfoID", "dbo.Contrast_UserInfo");
            DropForeignKey("dbo.Contrast_WorkflowMain", "Contrast_OrganizationID", "dbo.Contrast_Organization");
            DropForeignKey("dbo.Contrast_WorkflowMain", "Contrast_AccountID", "dbo.Contrast_Account");
            DropIndex("dbo.Contrast_Workflow", new[] { "Contrast_AccountID" });
            DropIndex("dbo.Contrast_WorkflowDetail", new[] { "Contrast_AccountID" });
            DropIndex("dbo.Contrast_WorkflowDetail", new[] { "Contrast_WorkflowID" });
            DropIndex("dbo.Contrast_WorkflowDetail", new[] { "Contrast_WorkflowMainID" });
            DropIndex("dbo.Contrast_WorkflowMain", new[] { "Contrast_UserInfoID" });
            DropIndex("dbo.Contrast_WorkflowMain", new[] { "Contrast_OrganizationID" });
            DropIndex("dbo.Contrast_WorkflowMain", new[] { "Contrast_AccountID" });
            DropTable("dbo.Contrast_Workflow");
            DropTable("dbo.Contrast_WorkflowDetail");
            DropTable("dbo.Contrast_UserInfo");
            DropTable("dbo.Contrast_Organization");
            DropTable("dbo.Contrast_WorkflowMain");
            DropTable("dbo.Contrast_Account");
        }
    }
}
