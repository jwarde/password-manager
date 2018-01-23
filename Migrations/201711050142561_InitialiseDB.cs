namespace Pass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialiseDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetailsMain",
                c => new
                    {
                        PwdId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DateTimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Completed = c.Boolean(nullable: false),
                        Category = c.Int(nullable: false),
                        SubCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PwdId);
            
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        PwdId = c.Int(nullable: false),
                        Account_Name = c.String(nullable: false, maxLength: 50),
                        URI = c.String(),
                        Location = c.String(),
                        Password_1 = c.String(),
                    })
                .PrimaryKey(t => t.PwdId)
                .ForeignKey("dbo.AccountDetailsMain", t => t.PwdId)
                .Index(t => t.PwdId);
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        PwdId = c.Int(nullable: false),
                        Account_Holder_First_Name = c.String(nullable: false, maxLength: 50),
                        Account_Holder_Last_Name = c.String(nullable: false, maxLength: 50),
                        Email_Address_Main = c.String(maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        Tel = c.String(maxLength: 15),
                        Mobile = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.PwdId)
                .ForeignKey("dbo.AccountDetailsMain", t => t.PwdId)
                .Index(t => t.PwdId);
            
            CreateTable(
                "dbo.AddressDetails",
                c => new
                    {
                        PwdId = c.Int(nullable: false),
                        Address_1 = c.String(maxLength: 70),
                        Address_2 = c.String(maxLength: 70),
                        Town = c.String(maxLength: 30),
                        Region = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Post_Code_Zip = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.PwdId)
                .ForeignKey("dbo.AccountDetailsMain", t => t.PwdId)
                .Index(t => t.PwdId);
            
            CreateTable(
                "dbo.SecurityDetails",
                c => new
                    {
                        PwdId = c.Int(nullable: false),
                        Question_1 = c.String(maxLength: 300),
                        Answer_1 = c.String(maxLength: 250),
                        Question_2 = c.String(maxLength: 300),
                        Question_3 = c.String(maxLength: 300),
                        Answer_3 = c.String(maxLength: 250),
                        Question_4 = c.String(maxLength: 300),
                        Answer_4 = c.String(maxLength: 250),
                        Question_5 = c.String(maxLength: 300),
                        Answer_5 = c.String(maxLength: 250),
                        Mother_Maiden_Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PwdId)
                .ForeignKey("dbo.AccountDetailsMain", t => t.PwdId)
                .Index(t => t.PwdId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        PwdId = c.Int(nullable: false),
                        Notes = c.String(),
                        Misc = c.String(),
                    })
                .PrimaryKey(t => t.PwdId)
                .ForeignKey("dbo.AccountDetailsMain", t => t.PwdId)
                .Index(t => t.PwdId);
            
            CreateTable(
                "dbo.Pwd51",
                c => new
                    {
                        PwdId = c.Int(nullable: false),
                        Password_2 = c.String(),
                        Answer_2 = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.PwdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "PwdId", "dbo.AccountDetailsMain");
            DropForeignKey("dbo.SecurityDetails", "PwdId", "dbo.AccountDetailsMain");
            DropForeignKey("dbo.AddressDetails", "PwdId", "dbo.AccountDetailsMain");
            DropForeignKey("dbo.ContactDetails", "PwdId", "dbo.AccountDetailsMain");
            DropForeignKey("dbo.AccountDetails", "PwdId", "dbo.AccountDetailsMain");
            DropIndex("dbo.Notes", new[] { "PwdId" });
            DropIndex("dbo.SecurityDetails", new[] { "PwdId" });
            DropIndex("dbo.AddressDetails", new[] { "PwdId" });
            DropIndex("dbo.ContactDetails", new[] { "PwdId" });
            DropIndex("dbo.AccountDetails", new[] { "PwdId" });
            DropTable("dbo.Pwd51");
            DropTable("dbo.Notes");
            DropTable("dbo.SecurityDetails");
            DropTable("dbo.AddressDetails");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.AccountDetails");
            DropTable("dbo.AccountDetailsMain");
        }
    }
}
