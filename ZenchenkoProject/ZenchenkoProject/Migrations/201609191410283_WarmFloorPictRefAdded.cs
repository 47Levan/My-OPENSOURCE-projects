namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorPictRefAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmFloors", "PictureRef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WarmFloors", "PictureRef");
        }
    }
}
