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
            DatabaseModel model = new DatabaseModel();
            using (GoodsContainer1 goods = new GoodsContainer1())
            {    
                model.Categories = goods.CategorySet.ToList();
                model.SubCategories = goods.SubCategorySet.ToList();
            }
            return PartialView(model);
           
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
        [HttpGet]
        public ActionResult AddProducts()
        {
          
            using (GoodsContainer1 goods = new GoodsContainer1())
            {
                ViewData["Categories"] = goods.CategorySet;
                ViewData["SubCategories"] = goods.SubCategorySet;
                ViewData["Categories"] = goods.CategorySet;
        

            return PartialView();
            }
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
                ViewData["Categories"] = container.CategorySet;
                ViewData["SubCategories"] = container.SubCategorySet;
                ViewData["Products"] = container.ProductSet;             
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
            List<SubCategory> subs = new List<SubCategory>();
            using (GoodsContainer1 goods=new GoodsContainer1())
            {
                subs = goods.SubCategorySet.Where(x => x.Category.Id == category).ToList();
            }
            return Json(new SelectList(subs, "Id", "Subcategory"));
        }
    }
  
}