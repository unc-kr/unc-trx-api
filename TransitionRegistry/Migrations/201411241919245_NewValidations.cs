namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewValidations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Race", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "Email", c => c.String());
            AddColumn("dbo.Patients", "PhoneNumber", c => c.String());
            AddColumn("dbo.Patients", "Diagnosis", c => c.Int(nullable: false));
            AddColumn("dbo.Studies", "Grant", c => c.String(maxLength: 512));
            AddColumn("dbo.Studies", "Description", c => c.String(maxLength: 2048));
            AlterColumn("dbo.Patients", "MrnNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Description", c => c.String(maxLength: 2048));
            AlterColumn("dbo.Patients", "ArchiveDescription", c => c.String(maxLength: 2048));
            AlterColumn("dbo.Studies", "ShortCode", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Studies", "Name", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Studies", "ArchiveDescription", c => c.String(maxLength: 2048));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Studies", "ArchiveDescription", c => c.String());
            AlterColumn("dbo.Studies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Studies", "ShortCode", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "ArchiveDescription", c => c.String());
            AlterColumn("dbo.Patients", "Description", c => c.String());
            AlterColumn("dbo.Patients", "MrnNumber", c => c.String());
            DropColumn("dbo.Studies", "Description");
            DropColumn("dbo.Studies", "Grant");
            DropColumn("dbo.Patients", "Diagnosis");
            DropColumn("dbo.Patients", "PhoneNumber");
            DropColumn("dbo.Patients", "Email");
            DropColumn("dbo.Patients", "Race");
        }
    }
}
