using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    public class AboutShopController : Controller
    {
        public ActionResult ShowSelector(string showCriteria)
        {
            if (showCriteria == "History")
            {
                return RedirectToAction("History");
            }
            else if(showCriteria== "Why we")
            {
                return RedirectToAction("Why_We");
            }
            else if(showCriteria == "Our team")
            {
                return RedirectToAction("Our_Team");
            }
            else if(showCriteria == "News")
            {
                return RedirectToAction("News");
            }
            return RedirectToAction("History");
        }
        // GET: AboutShop
        [HttpGet]
        public ActionResult History()
        {
            return PartialView();
        }
        public ActionResult Why_We()
        {
            return PartialView();
        }
        public ActionResult News()
        {
            NewsDBContext news = new NewsDBContext();
            return PartialView(news.newsDataSet.ToList());
        }
        public ActionResult Our_Team()
        {
            return PartialView();
        }

    }
}