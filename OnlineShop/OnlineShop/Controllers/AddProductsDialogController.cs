using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.OnlineShopDatabase;
using OnlineShop.Models.OnlineShopDatabase.Goods;

namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class AddProductsDialogController : Controller
    {
        private IProductOperations prod;
        public AddProductsDialogController(IProductOperations userProd)
        {
            prod = userProd;
        }
        // GET: AddProducts
        [HttpGet]
        public ActionResult AddProducts()
        {
            OnlineShopDbContext goods = new OnlineShopDbContext();
            ViewData["Categories"] = goods.Categories;
            ViewData["SubCategories"] = new List<SubCategory>();
            ViewBag.SubCat = string.Empty;
            Product product = new Product();
            product.Descriptions = new List<DescriptionParameters>();
            product.Descriptions.Add(new DescriptionParameters());
            return PartialView(product);
        }
        [HttpPost]
        public ActionResult ShowAddedProduct(Product product, HttpPostedFileBase uploadedImage)
        {
            if (product.Article == null
                 && product.Name == null
                 && product.Picture == null
                 && product.Price == 0)
            {
                return RedirectToAction("AddProducts");
            }
            product=prod.postAddProduct(product,uploadedImage);            
            return PartialView("~/Views/AddProductsDialog/AddedProduct.cshtml", product);   
        }
        [HttpGet]
        public ActionResult AddDescriptionPatrameter(Product product, Guid? categoryId)
        {
            product.Descriptions.Add(new DescriptionParameters());
            OnlineShopDbContext goods = new OnlineShopDbContext();
            if (categoryId != null)
            {
                ViewData["Categories"] = goods.Categories;
                ViewData["SubCategories"] = goods.SubCategories.Where(x => x.Category_Id == categoryId).ToList();
            }
            return PartialView("~/Views/AddProductsDialog/AddRemoveDescription.cshtml", product);
        }
        [HttpGet]
        public ActionResult RemoveDescriptionParameter(Product product,string description,
            string descriptionParametr, Guid? categoryId)
        {
            if(description=="")
            {
                description = null;
            }
            if (descriptionParametr == "")
            {
                descriptionParametr = null;
            }
            if (product.Descriptions.Count > 1)
            {
                product.Descriptions.Remove(
                    product.Descriptions.FirstOrDefault(x=>x.Description==description 
                    && x.DescriptionParameter==descriptionParametr));
            }
            OnlineShopDbContext goods = new OnlineShopDbContext();
            if (categoryId != null)
            {
                ViewData["Categories"] = goods.Categories;
                ViewData["SubCategories"] = goods.SubCategories.Where(x => x.Category_Id == categoryId).ToList();
            }
            return PartialView("~/Views/AddProductsDialog/AddRemoveDescription.cshtml", product);
        }
    }
}