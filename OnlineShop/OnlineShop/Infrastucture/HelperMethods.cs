using System.Collections.Generic;
using System.Web.Mvc;
using OnlineShop.Models;
namespace OnlineShop.Infrastucture
{
    public static class HelperMethods
    {
        public static MvcHtmlString getNews(this HtmlHelper html,List<News> newsList)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (News news in newsList)
            {

            }
            return new MvcHtmlString(null);
        }
    }
}
