namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorGarantyChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WarmFloors", "Garanty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WarmFloors", "Garanty", c => c.String());
        }
    }
}
