using System.Linq;
using System.Web.Mvc;
using OnlineShop.Models.OnlineShopDatabase;
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
                OnlineShopDbContext news = new OnlineShopDbContext();
                return PartialView("~/Views/AboutShop/News.cshtml",news.Newses.ToList());
            }
            return PartialView("~/Views/AboutShop/History.cshtml");
        }
        [HttpPost]
        public ActionResult ShowNews(string pagelink)
        {
            OnlineShopDbContext news = new OnlineShopDbContext();
            return PartialView(pagelink,news.Newses.FirstOrDefault(x=>x.FullPageLink==pagelink));
        }
        [HttpPost]
        public ActionResult SortNews(string sortParameters)
        {
            OnlineShopDbContext news = new OnlineShopDbContext();
            if (sortParameters == "Newest")
            {
                return PartialView("~/Views/PartialViews/NewsList.cshtml",
                news.Newses.OrderByDescending(x => x.DateAdded).ToList());
            }
            else
            {

                return PartialView("~/Views/PartialViews/NewsList.cshtml",
                news.Newses.OrderBy(x => x.DateAdded).ToList());
            }
        }
    }
}