using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using System.Collections;
using System.IO;
using System.Data.Entity;
using System.Web.Helpers;
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
            GoodsContainer1 goods = new GoodsContainer1();          
            return PartialView(goods);           
        }    
        [HttpPost]
        public JsonResult GetSubs(int category)
        {
            IEnumerable<SubCategory> subs;
            using (GoodsContainer1 goods=new GoodsContainer1())
            {
                subs =  goods.SubCategorySet.Where(x => x.Category.Id == category).ToList(); 
            }
            
           return Json(new SelectList(subs, "Id", "Subcategory"));
        }
    }
  
}