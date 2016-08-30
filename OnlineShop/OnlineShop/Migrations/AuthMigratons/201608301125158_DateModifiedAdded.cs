namespace OnlineShop.Migrations.AuthMigratons
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateModifiedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isModified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DateModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateModified");
            DropColumn("dbo.AspNetUsers", "isModified");
        }
    }
}
