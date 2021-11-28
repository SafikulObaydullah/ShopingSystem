namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Salary = c.String(nullable: false, maxLength: 6),
                        HRRate = c.String(nullable: false, maxLength: 6),
                        MARate = c.String(nullable: false, maxLength: 6),
                        Bonous = c.String(nullable: false, maxLength: 6),
                        PF = c.String(nullable: false, maxLength: 6),
                        Tax = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Salary = c.String(nullable: false, maxLength: 6),
                        HRRate = c.String(nullable: false, maxLength: 6),
                        MARate = c.String(nullable: false, maxLength: 6),
                        Bonous = c.String(nullable: false, maxLength: 6),
                        PF = c.String(nullable: false, maxLength: 6),
                        Tax = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grades");
            DropTable("dbo.Designations");
        }
    }
}
