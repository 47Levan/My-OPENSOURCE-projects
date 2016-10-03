namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmFloors", "Article", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WarmFloors", "Article");
        }
    }
}
