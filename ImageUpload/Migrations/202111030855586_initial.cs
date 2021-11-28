namespace ImageUpload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        ShortName = c.String(nullable: false, maxLength: 6),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 6),
                        DOB = c.DateTime(nullable: false),
                        DeptID = c.Int(nullable: false),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DeptID, cascadeDelete: true)
                .Index(t => t.DeptID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DeptID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DeptID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
