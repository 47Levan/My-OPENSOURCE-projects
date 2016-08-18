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
//            context.newsDataSet.AddOrUpdate(
//                  new News
//                  {
//                      categories = Categories.Internet,
//                      DateAdded = DateTime.Now,
//                      ShortDiscription = @"Commentary: For Road Trip 2016, I tried to go beyond the wall
//of silence that hides refugees in Australian-funded detention camps in the Pacific. What I found is that
//even in the tech age, connecting with the disconnected is harder than you can imagine.",
//                      PreviewPicture = "~/Images/NewsPreview/Internet/1.jpg",
//                      FullPageLink = "~/Views/News/Internet/News1.cshtml",
//                      Title = "WhatsApp messages from a 'prison' island, thousands of miles away"
//                  },
//                   new News
//                   {
//                       categories = Categories.Internet,
//                       DateAdded = DateTime.Now,
//                       ShortDiscription = @"The US government will pass guardianship of the internet
//domain naming system to a private nonprofit in October",
//                       PreviewPicture = "~/Images/NewsPreview/Internet/2.jpg",
//                       FullPageLink = "~/Views/News/Internet/News2.cshtml",
//                       Title = "US prepares to hand over power of the internet's naming system"
//                   },
//                     new News
//                     {
//                         categories = Categories.Smart_Phones,
//                         DateAdded = DateTime.Now,
//                         ShortDiscription = @"A presence in India is crucial for the world's third biggest phone maker.",
//                         PreviewPicture = "~/Images/NewsPreview/SmartPhones/3.jpg",
//                         FullPageLink = "~/Views/News/SmartPhones/News3.cshtml",
//                         Title = "Beast of the east: Huawei to build phones in India"
//                     }

//                );
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
