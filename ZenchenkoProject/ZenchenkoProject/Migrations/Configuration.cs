using ZenchenkoProject.Models;
using System.Data.Entity.Migrations;
namespace ZenchenkoProject.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            FillRandomData rnd = new FillRandomData();
            rnd.FillWarmFloor(context);
        }
    }
}
