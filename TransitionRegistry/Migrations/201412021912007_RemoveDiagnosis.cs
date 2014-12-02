namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDiagnosis : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "Diagnosis");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Diagnosis", c => c.Int(nullable: false));
        }
    }
}
