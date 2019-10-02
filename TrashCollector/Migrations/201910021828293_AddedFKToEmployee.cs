namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserGuid", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "UserGuid");
            AddForeignKey("dbo.Employees", "UserGuid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UserGuid", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UserGuid" });
            DropColumn("dbo.Employees", "UserGuid");
        }
    }
}
