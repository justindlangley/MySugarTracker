namespace MySugarTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DrID", c => c.String());
            AddColumn("dbo.Patients", "CMId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "CMId");
            DropColumn("dbo.Patients", "DrID");
        }
    }
}
