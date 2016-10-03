namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorUpdate31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmFloors", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WarmFloors", "Description");
        }
    }
}
