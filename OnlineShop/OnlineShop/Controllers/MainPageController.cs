using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineShop.Models.OnlineShopDatabase;
using OnlineShop.Models.OnlineShopDatabase.Goods;

namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class MainPageController : Controller
    {
        List<Category> categoryListForButtonList = new List<Category>();
        List<SubCategory> subCategoryListForButtonList = new List<SubCategory>();
        // GET: Home
        public ActionResult Index()
        {        
                return View();         
        }
        public ActionResult showCatButton()
        {
            OnlineShopDbContext goods = new OnlineShopDbContext();          
            return PartialView(goods);           
        }    
        [HttpPost]
        public JsonResult GetSubs(Guid? category)
        {
            IEnumerable<SubCategory> subs;
            using (OnlineShopDbContext goods=new OnlineShopDbContext())
            {
                subs =  goods.SubCategories.Where(x => x.Category.Id == category).ToList(); 
            }
            
           return Json(new SelectList(subs, "Id", "Subcategory"));
        }
    }
  
}