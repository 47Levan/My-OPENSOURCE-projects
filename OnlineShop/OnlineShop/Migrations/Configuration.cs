namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OnlineShop.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.Models.NewsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineShop.Models.NewsDBContext context)
        {
            context.newsDataSet.AddOrUpdate(
                  new News
                  {
                      categories = Categories.Smart_Phones,
                      DateAdded = DateTime.Now,
                      ShortDiscription = @"The carriers unveiled new unlimited data plans that 
are significantly less expensive than previous offers. But which one is really the better deal?",
                      PreviewPicture = "~/Images/NewsPreview/SmartPhones/3.jpg",
                      FullPageLink = "~/Views/News/SmartPhones/News3.cshtml",
                      Title = @"T-Mobile vs. Sprint: The battle for unlimited data"
                  }
                                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
