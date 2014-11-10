namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nov9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Description", c => c.String());
            AddColumn("dbo.Patients", "Archived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "ArchiveDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ArchiveDescription");
            DropColumn("dbo.Patients", "Archived");
            DropColumn("dbo.Patients", "Description");
        }
    }
}
