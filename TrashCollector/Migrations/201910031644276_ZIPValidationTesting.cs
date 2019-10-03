namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZIPValidationTesting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ZIP", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "ZIP", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ZIP", c => c.String());
            AlterColumn("dbo.Customers", "ZIP", c => c.String());
        }
    }
}
