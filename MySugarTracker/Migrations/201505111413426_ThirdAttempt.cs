namespace MySugarTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdAttempt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        BirthDate = c.DateTime(nullable: false),
                        CardioVascularDisease = c.Boolean(nullable: false),
                        HighBloodPressure = c.Boolean(nullable: false),
                        ThyroidDisease = c.Boolean(nullable: false),
                        Female = c.Boolean(nullable: false),
                        Pregnant = c.Boolean(nullable: false),
                        EmailPref = c.Boolean(nullable: false),
                        SMSpref = c.Boolean(nullable: false),
                        LowAlert = c.Int(nullable: false),
                        HighAlert = c.Int(nullable: false),
                        TestTime1 = c.DateTime(nullable: false),
                        TestTime2 = c.DateTime(nullable: false),
                        TestTime3 = c.DateTime(nullable: false),
                        TestTime4 = c.DateTime(nullable: false),
                        WeightInPounds = c.Int(nullable: false),
                        HeightInInches = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PatientSugarDatas",
                c => new
                    {
                        PatientSugarDataID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        patientSugarReading = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientSugarDataID)
                .ForeignKey("dbo.Patients", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientSugarDatas", "UserID", "dbo.Patients");
            DropForeignKey("dbo.Patients", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PatientSugarDatas", new[] { "UserID" });
            DropIndex("dbo.Patients", new[] { "ApplicationUser_Id" });
            DropTable("dbo.PatientSugarDatas");
            DropTable("dbo.Patients");
        }
    }
}
