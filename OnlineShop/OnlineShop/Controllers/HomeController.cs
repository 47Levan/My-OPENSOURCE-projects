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
    public class HomeController : Controller
    {
        static GoodsContainer1 goods = new GoodsContainer1();
        public HomeController()
        {
            
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewData["SubCategories"] = goods.SubCategorySet;
            ViewData["Categories"] = goods.CategorySet;
            return View();
        }
        public ActionResult showCatButton()
        {
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet;
            return PartialView();
        }
        [HttpGet]
        public ActionResult showProductsByFilter(string category)
        {
            
            category = category.Trim();
            ViewData["category"]= category;
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet;
            return PartialView();
        }
        [HttpGet]
        public ActionResult AddProducts()
        {
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet;
            ViewData["Products"] = goods.ProductSet;
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddProducts(Product product,HttpPostedFileBase uploadedImage)
        {
         
            
           
            product.DateAdded =DateTime.Now;
            if (uploadedImage !=null && uploadedImage.ContentLength>0)
            {
                using (BinaryReader reader = new BinaryReader(uploadedImage.InputStream))
                {
                    product.Picture = reader.ReadBytes(uploadedImage.ContentLength);
                }
            }
            using (GoodsContainer1 container = new GoodsContainer1())
            {
                ViewData["Categories"] = goods.CategorySet;
                ViewData["SubCategories"] = goods.SubCategorySet;
                ViewData["Products"] = goods.ProductSet;
                int? maxId = container.ProductSet.Max(x => (int?)x.Id) + 1;
                if (maxId != null)
                {
                    product.Id = (int)maxId + 1;
                }
                else
                {
                    product.Id = 1;
                }
                product.SubCategory = container.SubCategorySet.FirstOrDefault(x => x.Id == product.selectedSub);
                if (product.Article != null
                    && product.Name != null
                    && product.Description != null
                    && product.Picture != null
                    && product.Price != 0)
                {
                    container.ProductSet.Add(product);
                    container.SaveChanges();
                    ModelState.Clear();
                    return PartialView("AddedProduct");
                }
            }

            ModelState.Clear();
            return PartialView("AddedProduct",product);
           
        }
        [HttpPost]
        public JsonResult GetSubs(int category)
        {
            List<SubCategory> subs = goods.SubCategorySet.Where(x=>x.Category.Id==category).ToList();
            return Json(new SelectList(subs, "Id", "Subcategory"));
        }
    }
  
}