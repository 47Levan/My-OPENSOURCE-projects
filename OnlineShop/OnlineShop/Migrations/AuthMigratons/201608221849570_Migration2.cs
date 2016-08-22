namespace OnlineShop.Migrations.AuthMigratons
{
    using System;
    using System.Data.Entity.Migrations;
    using OnlineShop.Models.Authentication;
    using Microsoft.AspNet.Identity.EntityFramework;
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AuthDBContext auth = new AuthDBContext();
            auth.Roles.AddOrUpdate(new IdentityRole {Name="Admin",Id="Admin" });
            auth.Roles.AddOrUpdate(new IdentityRole { Name = "Moderator", Id = "Moderator" });
            auth.Roles.AddOrUpdate(new IdentityRole { Name = "User", Id = "User" });
            auth.SaveChanges();
        }
        
        public override void Down()
        {
            IdentityRole role;
            AuthDBContext auth = new AuthDBContext();
            role = new IdentityRole { Id = "Admin" };
            auth.Roles.Attach(role);
            auth.Roles.Remove(role);
            role = new IdentityRole { Id = "Moderator" };
            auth.Roles.Attach(role);
            auth.Roles.Remove(role);
            role = new IdentityRole { Id = "User" };
            auth.Roles.Attach(role);
            auth.Roles.Remove(role);
            auth.SaveChanges();
        }
    }
}
