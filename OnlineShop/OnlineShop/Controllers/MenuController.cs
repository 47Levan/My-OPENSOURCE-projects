using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.OnlineShopDatabase;

namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        static OnlineShopDbContext goods = new OnlineShopDbContext();
        // GET: Menu
        public ActionResult Contacts()
        {
           
            return View();
        }
        public ActionResult AboutShop()
        {
          
            return View();
        }
        public ActionResult MethodsOfDelivery()
        {

            return View();
        }

    }
}