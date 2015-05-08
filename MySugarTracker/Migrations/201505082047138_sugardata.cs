namespace MySugarTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sugardata : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PatientSugarDatas", new[] { "Patient_UserID" });
            DropColumn("dbo.PatientSugarDatas", "UserID");
            RenameColumn(table: "dbo.PatientSugarDatas", name: "Patient_UserID", newName: "UserID");
            AlterColumn("dbo.PatientSugarDatas", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.PatientSugarDatas", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PatientSugarDatas", new[] { "UserID" });
            AlterColumn("dbo.PatientSugarDatas", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PatientSugarDatas", name: "UserID", newName: "Patient_UserID");
            AddColumn("dbo.PatientSugarDatas", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientSugarDatas", "Patient_UserID");
        }
    }
}
