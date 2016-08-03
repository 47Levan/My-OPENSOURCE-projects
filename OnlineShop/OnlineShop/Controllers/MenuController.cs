using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    public class MenuController : Controller
    {
        static GoodsContainer1 goods = new GoodsContainer1();
        // GET: Menu
        public ActionResult Contacts()
        {
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet;
            return View();
        }
        public ActionResult AboutShop()
        {
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet;
            return View();
        }
        public ActionResult MethodsOfDelivery()
        {
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet;
            return View();
        }
    }
}