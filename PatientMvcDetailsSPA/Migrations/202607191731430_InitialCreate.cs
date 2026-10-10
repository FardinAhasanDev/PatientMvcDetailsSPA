namespace PatientMvcDetailsSPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable("dbo.Patients", c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                        MobileNo = c.String(),
                        RegistrationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsEnrolled = c.Boolean(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable("dbo.Prescriptions", c => new
                    {
                        PrescriptionId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        MedicineName = c.String(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrescriptionId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
        }
    }
}
