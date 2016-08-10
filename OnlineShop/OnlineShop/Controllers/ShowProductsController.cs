using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    public class ShowProductsController : Controller
    {
        // GET: ShowProducts
        [HttpGet]
        public ActionResult showProductsByFilter(string category)
        {
              category = category.Trim();
            ViewData["category"] = category;
            GoodsContainer1 goods = new GoodsContainer1();
           
                List<Product> products = new List<Product>();
                products = goods.ProductSet.Where(x=>x.SubCategory.Subcategory==category).ToList();
                ViewData["SubCategories"] = goods.SubCategorySet;
                ViewData["Categories"] = goods.CategorySet;

                return PartialView(products);
            
        }
        public ActionResult showOneProduct(Product product)
        {
            return PartialView(product);
        }
    }
}