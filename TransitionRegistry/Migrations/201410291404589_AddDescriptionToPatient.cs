namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Description");
        }
    }
}
