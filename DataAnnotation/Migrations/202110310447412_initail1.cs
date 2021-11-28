namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Designations", "creationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Designations", "creationDate");
        }
    }
}
