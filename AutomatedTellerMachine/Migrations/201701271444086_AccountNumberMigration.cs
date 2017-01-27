namespace AutomatedTellerMachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountNumberMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChekingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(nullable: false, maxLength: 10),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChekingAccounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ChekingAccounts", new[] { "ApplicationUserId" });
            DropTable("dbo.ChekingAccounts");
        }
    }
}
