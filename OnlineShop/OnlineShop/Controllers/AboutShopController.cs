using System.Linq;
using System.Web.Mvc;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class AboutShopController : Controller
    {
        [HttpPost]
        public ActionResult ShowSelector(string showCriteria)
        {
            if (showCriteria == "History")
            {
                return PartialView("~/Views/AboutShop/History.cshtml");
            }
            else if(showCriteria== "Why we")
            {
                return PartialView("~/Views/AboutShop/Why_We.cshtml");
            }
            else if(showCriteria == "Our team")
            {
                return PartialView("~/Views/AboutShop/Our_Team.cshtml");
            }
            else if(showCriteria == "News")
            {
                NewsDBContext news = new NewsDBContext();
                return PartialView("~/Views/AboutShop/News.cshtml",news.newsDataSet.ToList());
            }
            return PartialView("~/Views/AboutShop/History.cshtml");
        }
        [HttpPost]
        public ActionResult ShowNews(string pagelink)
        {
            NewsDBContext news = new NewsDBContext();
            return PartialView(pagelink,news.newsDataSet.FirstOrDefault(x=>x.FullPageLink==pagelink));
        }
        [HttpPost]
        public ActionResult SortNews(string sortParameters)
        {
            NewsDBContext news = new NewsDBContext();
            if (sortParameters == "Newest")
            {
                return PartialView("~/Views/PartialViews/NewsList.cshtml",
                news.newsDataSet.OrderByDescending(x => x.DateAdded).ToList());
            }
            else
            {

                return PartialView("~/Views/PartialViews/NewsList.cshtml",
                news.newsDataSet.OrderBy(x => x.DateAdded).ToList());
            }
        }
    }
}