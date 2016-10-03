namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoruLinkAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Controller", c => c.String());
            AddColumn("dbo.Categories", "ActionMethod", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ActionMethod");
            DropColumn("dbo.Categories", "Controller");
        }
    }
}
