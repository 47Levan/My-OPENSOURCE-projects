using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Models.OnlineShopDatabase.Authentication;
using OnlineShop.Models.OnlineShopDatabase.Goods;
using System.Data.Entity;
namespace OnlineShop.Models.OnlineShopDatabase
{
    public class OnlineShopDbContext :IdentityDbContext<User>
    {
        public OnlineShopDbContext() :base("OnlineShop")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<DescriptionParameters> DescriptionList { get; set; }
        public DbSet<OnlineShop.Models.OnlineShopDatabase.NewsDataBase.NewsList> Newses { get; set; }
    }
}
