namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class add : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Contrast_UserInfo");
            DropTable("dbo.Contrast_Organization");
        }
    }
}
