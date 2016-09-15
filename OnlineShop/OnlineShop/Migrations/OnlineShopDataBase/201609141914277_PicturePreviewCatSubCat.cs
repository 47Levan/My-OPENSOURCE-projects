namespace OnlineShop.Migrations.OnlineShopDataBase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PicturePreviewCatSubCat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "PictureRef", c => c.String());
            AddColumn("dbo.SubCategories", "PictureRef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubCategories", "PictureRef");
            DropColumn("dbo.Categories", "PictureRef");
        }
    }
}
