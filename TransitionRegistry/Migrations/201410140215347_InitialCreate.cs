namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MrnNumber = c.String(),
                        Birthday = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.Int(nullable: false),
                        ParticipantType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Studies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudyPatients",
                c => new
                    {
                        Study_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Study_Id, t.Patient_Id })
                .ForeignKey("dbo.Studies", t => t.Study_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Study_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudyPatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.StudyPatients", "Study_Id", "dbo.Studies");
            DropIndex("dbo.StudyPatients", new[] { "Patient_Id" });
            DropIndex("dbo.StudyPatients", new[] { "Study_Id" });
            DropTable("dbo.StudyPatients");
            DropTable("dbo.Studies");
            DropTable("dbo.Patients");
        }
    }
}
