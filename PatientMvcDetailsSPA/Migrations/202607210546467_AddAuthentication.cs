namespace PatientMvcDetailsSPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthentication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.tbl_UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_User");
            DropTable("dbo.tbl_UserRole");
            DropTable("dbo.tbl_Role");
        }
    }
}
