namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArchivedToStudies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Studies", "Archived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Studies", "ArchiveDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Studies", "ArchiveDescription");
            DropColumn("dbo.Studies", "Archived");
        }
    }
}
