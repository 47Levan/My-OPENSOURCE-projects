namespace OnlineShop.Migrations.AuthMigratons
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictDateColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Picture", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateAdded");
            DropColumn("dbo.AspNetUsers", "Picture");
        }
    }
}
