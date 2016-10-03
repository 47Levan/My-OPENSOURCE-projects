namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorIsInStockAdded2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmFloors", "ProtectScreen", c => c.String());
            AddColumn("dbo.WarmFloors", "OuterSheald", c => c.String());
            DropColumn("dbo.WarmFloors", "Shield");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WarmFloors", "Shield", c => c.String());
            DropColumn("dbo.WarmFloors", "OuterSheald");
            DropColumn("dbo.WarmFloors", "ProtectScreen");
        }
    }
}
