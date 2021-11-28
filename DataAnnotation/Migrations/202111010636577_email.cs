namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Designations", "Tax", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Designations", "Tax", c => c.String());
            DropColumn("dbo.Grades", "Email");
        }
    }
}
