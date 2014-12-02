namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimestamps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Patients", "LastModifiedDate", c => c.DateTime());
            AddColumn("dbo.Patients", "LastAccessDate", c => c.DateTime());
            AddColumn("dbo.Studies", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Studies", "LastModifiedDate", c => c.DateTime());
            AddColumn("dbo.Studies", "LastAccessDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Studies", "LastAccessDate");
            DropColumn("dbo.Studies", "LastModifiedDate");
            DropColumn("dbo.Studies", "CreatedDate");
            DropColumn("dbo.Patients", "LastAccessDate");
            DropColumn("dbo.Patients", "LastModifiedDate");
            DropColumn("dbo.Patients", "CreatedDate");
        }
    }
}
