namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Studies", "ShortCode", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Studies", "ShortCode");
        }
    }
}
