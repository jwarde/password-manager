namespace Pass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDeal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccountDetailsMain", "DateTimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountDetailsMain", "DateTimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
