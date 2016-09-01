using System.Collections.Generic;
using System.Web.Mvc;
using OnlineShop.Models.OnlineShopDatabase.NewsDataBase;
namespace OnlineShop.Infrastucture
{
    public static class HelperMethods
    {
        public static MvcHtmlString getNews(this HtmlHelper html,List<NewsList> newsList)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (NewsList news in newsList)
            {

            }
            return new MvcHtmlString(null);
        }
    }
}
