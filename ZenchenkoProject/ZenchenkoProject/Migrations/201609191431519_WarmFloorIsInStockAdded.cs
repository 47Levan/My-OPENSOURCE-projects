namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorIsInStockAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmFloors", "IsInStock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WarmFloors", "IsInStock");
        }
    }
}
