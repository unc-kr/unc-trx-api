namespace TransitionRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Address", c => c.String(maxLength: 128));
            AddColumn("dbo.Patients", "ZipCode", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ZipCode");
            DropColumn("dbo.Patients", "Address");
        }
    }
}
