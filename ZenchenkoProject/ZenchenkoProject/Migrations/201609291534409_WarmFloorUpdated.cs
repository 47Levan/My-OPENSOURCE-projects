namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WarmFloors", "TypeOfRoom", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WarmFloors", "TypeOfRoom", c => c.Int(nullable: false));
        }
    }
}
