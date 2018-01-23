namespace Pass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePasswordCheck : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pwd51", "Password_2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pwd51", "Password_2", c => c.String());
        }
    }
}
