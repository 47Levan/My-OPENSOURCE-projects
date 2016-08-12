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
        public List<Product> calcForProductsByFilter(int? subCategory)
        {
            ViewData["category"] = subCategory;
            GoodsContainer1 goods = new GoodsContainer1();

            List<Product> products = new List<Product>();
            if (subCategory != null)
            {
                products = goods.ProductSet.Where(x => x.SubCategory.Id == subCategory).ToList();
            }
            else
            {
                products = goods.ProductSet.ToList();
            }
            ViewData["SubCategories"] = goods.SubCategorySet;
            ViewData["Categories"] = goods.CategorySet;
            ViewBag.clickedCategory = subCategory;
            return products;
        }
        // GET: ShowProducts
        [HttpGet]
        public ActionResult showProductsByFilter(int? subCategory=null,int pageNumber=1,string orderType=null)
        {
            List<Product> products=new List<Product>();
            ViewBag.OrderType=orderType;
            if (orderType == null)
            {
                products = calcForProductsByFilter(subCategory);
            }
            else
            {
                products = sortProducts(subCategory,orderType);
            }
            return PartialView("~/Views/ShowProducts/showProductsByFilter.cshtml", products.ToPagedList(pageNumber,2));            
        }
        [HttpGet]
        public ActionResult startShowProductsByFilter(int? subCategory, string orderType)
        {
            List<Product> products = calcForProductsByFilter(subCategory);
            return PartialView("~/Views/ShowProducts/ShowProductsDialog.cshtml", products.ToPagedList(1, 2));

        }
        public ActionResult showOneProduct(Product product)
        {
            return PartialView(product);
        }
        [HttpGet]
        public ActionResult showAllProducts(int pageNumber, string orderType)
        {
            GoodsContainer1 goods = new GoodsContainer1();
            return PartialView("~/Views/ShowProducts/ShowProductsDialog.cshtml", goods.ProductSet.ToList().ToPagedList(pageNumber, 2));
        }
        public List<Product> sortProducts(int? category,
            string orderType)
        {
            List<Product> products = new List<Product>();
            GoodsContainer1 goods = new GoodsContainer1();
            if (category == null)
            {
                switch (orderType)
                {
                    case "from cheap to expensive":
                        products = goods.ProductSet.OrderBy(x => x.Price).ToList();
                        break;
                    case "from expensive to cheap":
                        products = goods.ProductSet.OrderByDescending(x => x.Price).ToList();
                        break;
                    case "Newest":
                        products = goods.ProductSet.OrderByDescending(x => x.DateAdded).ToList();
                        break;
                    case "Oldest":
                        products = goods.ProductSet.OrderBy(x => x.DateAdded).ToList();
                        break;
                }
            }
            else
            {
                switch (orderType)
                {
                    case "from cheap to expensive":
                        products = goods.ProductSet.Where(x => x.SubCategory_Id == category).OrderBy(x => x.Price).ToList();
                        break;
                    case "from expensive to cheap":
                        products = goods.ProductSet.Where(x => x.SubCategory_Id == category).OrderByDescending(x => x.Price).ToList();
                        break;
                    case "Newest":
                        products = goods.ProductSet.Where(x => x.SubCategory_Id == category).OrderByDescending(x => x.DateAdded).ToList();
                        break;
                    case "Oldest":
                        products = goods.ProductSet.Where(x => x.SubCategory_Id == category).OrderBy(x => x.DateAdded).ToList();
                        break;
                }
            }
            return products;
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
                products = sortProducts(category, orderType);
                ViewBag.OrderType = orderType;
                return PartialView("~/Views/ShowProducts/showProductsByFilter.cshtml", products.ToPagedList(1, 2));
            }
          

        }
    }
}