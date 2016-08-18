using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using PagedList;
namespace OnlineShop.Controllers
{
    public class ShowProductsController : Controller
    {
        private IProductOperations prod;
        public ShowProductsController(IProductOperations productOperations)
        {
            prod = productOperations;
        }
     
        // GET: ShowProducts
        [HttpGet]
        public ActionResult showProductsByFilter(int? subCategory=null,int pageNumber=1,string orderType=null)
        {
            GoodsContainer1 goods = new GoodsContainer1();
            List<Product> products=new List<Product>();
            ViewBag.OrderType=orderType;
            if (orderType == null)
            {
                products=prod.calcForProductsByFilter(subCategory);
                ViewData["category"] = subCategory;
                ViewData["SubCategories"] = goods.SubCategorySet;
                ViewData["Categories"] = goods.CategorySet;
                ViewBag.clickedCategory = subCategory;
            }
            else
            {
                products = prod.sortProducts(subCategory,orderType);
            }
            return PartialView("~/Views/ShowProducts/showProductsByFilter.cshtml", products.ToPagedList(pageNumber,5));            
        }
        [HttpGet]
        public ActionResult startShowProductsByFilter(int? subCategory, string orderType)
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
            GoodsContainer1 goods = new GoodsContainer1();
            return PartialView("~/Views/ShowProducts/ShowProductsDialog.cshtml", goods.ProductSet.ToList().ToPagedList(pageNumber, 5));
        }
   
        [HttpPost]
        public ActionResult sortProductsByFilter(int? category,
            string orderType)
        {
            if (orderType == "Sort products")
            {
                return RedirectToAction("showProductsByFilter",new { subCategory=category });
            }
            else
            {
                List<Product> products = new List<Product>();
                GoodsContainer1 goods = new GoodsContainer1();
                products = prod.sortProducts(category, orderType);
                ViewBag.OrderType = orderType;
                return PartialView("~/Views/ShowProducts/showProductsByFilter.cshtml", products.ToPagedList(1, 5));
            }
          

        }
    }
}