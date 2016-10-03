namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WarmFloors", "PvcPuterSheath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WarmFloors", "PvcPuterSheath", c => c.String());
        }
    }
}
