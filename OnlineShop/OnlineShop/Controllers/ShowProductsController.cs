using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineShop.Models;
using PagedList;
using OnlineShop.Models.OnlineShopDatabase;
using OnlineShop.Models.OnlineShopDatabase.Goods;

namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class ShowProductsController : Controller
    {
        private IProductOperations prod;
        public ShowProductsController(IProductOperations productOperations)
        {
            prod = productOperations;
        }
     
        // GET: ShowProducts
        [HttpGet]
        public ActionResult showProductsByFilter(Guid? subCategory=null,int pageNumber=1,string orderType=null)
        {
            OnlineShopDbContext goods = new OnlineShopDbContext();
            List<Product> products=new List<Product>();
            ViewBag.OrderType=orderType;
            if (orderType == null)
            {
                products=prod.calcForProductsByFilter(subCategory);
                ViewData["category"] = subCategory;
                ViewData["SubCategories"] = goods.SubCategories;
                ViewData["Categories"] = goods.Categories;
                ViewBag.clickedCategory = subCategory;
            }
            else
            {
                products = prod.sortProducts(subCategory,orderType);
            }
            return PartialView("~/Views/ShowProducts/showProductsByFilter.cshtml", products.ToPagedList(pageNumber,5));            
        }
        [HttpGet]
        public ActionResult startShowProductsByFilter(Guid? subCategory, string orderType)
        {

            List<Product> products = prod.calcForProductsByFilter(subCategory);
            return PartialView("~/Views/ShowProducts/ShowProductsDialog.cshtml", products.ToPagedList(1, 5));

        }
        public ActionResult showOneProduct(Product product)
        {
            return PartialView(product);
        }
        [HttpGet]
        public ActionResult showAllProducts(int pageNumber, string orderType)
        {
            OnlineShopDbContext goods = new OnlineShopDbContext();
            return PartialView("~/Views/ShowProducts/ShowProductsDialog.cshtml", goods.Products.ToList().ToPagedList(pageNumber, 5));
        }
   
        [HttpPost]
        public ActionResult sortProductsByFilter(Guid? category,
            string orderType)
        {
            if (orderType == "Sort products")
            {
                return RedirectToAction("showProductsByFilter",new { subCategory=category });
            }
            else
            {
                List<Product> products = new List<Product>();
                OnlineShopDbContext goods = new OnlineShopDbContext();
                products = prod.sortProducts(category, orderType);
                ViewBag.OrderType = orderType;
                return PartialView("~/Views/ShowProducts/showProductsByFilter.cshtml", products.ToPagedList(1, 5));
            }
        }
        [Authorize(Roles ="User,Admin,Moderator")]
        [HttpPost]
        public ActionResult BuyProduct()
        {
            return View();
        }
    }
}