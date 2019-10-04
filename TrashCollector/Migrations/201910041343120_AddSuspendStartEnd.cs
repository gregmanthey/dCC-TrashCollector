namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuspendStartEnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspendStartDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Customers", "SuspendEndDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SuspendEndDate");
            DropColumn("dbo.Customers", "SuspendStartDate");
        }
    }
}
