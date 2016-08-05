using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using System.IO;
using System.Data.Entity;
using System.Web.Helpers;
namespace OnlineShop.Controllers
{
    public class MainPageController : Controller
    {
        List<Category> categoryListForButtonList = new List<Category>();
        List<SubCategory> subCategoryListForButtonList = new List<SubCategory>();
        public MainPageController()
        {
            
        }
        // GET: Home
        public ActionResult Index()
        {        
                return View();         
        }
        public ActionResult showCatButton()
        {
            GoodsContainer1 goods = new GoodsContainer1();          
            return PartialView(goods);
           
        }
        [HttpGet]
        public ActionResult showProductsByFilter(string category)
        {
            
            category = category.Trim();
            ViewData["category"]= category;
            using (GoodsContainer1 goods = new GoodsContainer1())
            {
                ViewData["SubCategories"] = goods.SubCategorySet;
                ViewData["Categories"] = goods.CategorySet;
           
            return PartialView();
            }
        }    
        [HttpPost]
        public JsonResult GetSubs(int category)
        {
            List<SubCategory> subs = new List<SubCategory>();
            using (GoodsContainer1 goods=new GoodsContainer1())
            {
                subs = goods.SubCategorySet.Where(x => x.Category.Id == category).ToList();
            }
            return Json(new SelectList(subs, "Id", "Subcategory"));
        }
    }
  
}