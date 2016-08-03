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