namespace Pass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccountDetailsMain", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccountDetailsMain", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
