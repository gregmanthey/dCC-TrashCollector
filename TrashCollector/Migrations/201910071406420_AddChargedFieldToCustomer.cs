namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChargedFieldToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ChargedForPickupOn", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ChargedForPickupOn");
        }
    }
}
