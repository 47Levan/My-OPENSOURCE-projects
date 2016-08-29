using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OnlineShop.Models;
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
            GoodsContainer1 goods = new GoodsContainer1();
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = new List<SubCategory>();
            ViewBag.SubCat = string.Empty;
            Product product = new Product();
            product.DescriptionParameters.Add(new DescriptionParameters());
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
        public ActionResult AddDescriptionPatrameter(Product product, int? categoryId)
        {
            product.DescriptionParameters.Add(new DescriptionParameters());
            GoodsContainer1 goods = new GoodsContainer1();
            if (categoryId != null)
            {
                ViewData["Categories"] = goods.CategorySet;
                ViewData["SubCategories"] = goods.SubCategorySet.Where(x => x.Category.Id == categoryId).ToList();
            }
            return PartialView("~/Views/AddProductsDialog/AddRemoveDescription.cshtml", product);
        }
        [HttpGet]
        public ActionResult RemoveDescriptionParameter(Product product,string description,
            string descriptionParametr, int? categoryId)
        {
            if(description=="")
            {
                description = null;
            }
            if (descriptionParametr == "")
            {
                descriptionParametr = null;
            }
            if (product.DescriptionParameters.Count > 1)
            {
                product.DescriptionParameters.Remove(
                    product.DescriptionParameters.FirstOrDefault(x=>x.Description==description 
                    && x.DescriptionParameter==descriptionParametr));
            }
            GoodsContainer1 goods = new GoodsContainer1();
            if (categoryId != null)
            {
                ViewData["Categories"] = goods.CategorySet;
                ViewData["SubCategories"] = goods.SubCategorySet.Where(x => x.Category.Id == categoryId).ToList();
            }
            return PartialView("~/Views/AddProductsDialog/AddRemoveDescription.cshtml", product);
        }
    }
}