namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateFieldChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickupDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickupDate", c => c.DateTime(nullable: false));
        }
    }
}
