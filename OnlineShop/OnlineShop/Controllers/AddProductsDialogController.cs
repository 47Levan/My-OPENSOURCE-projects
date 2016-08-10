using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    public class AddProductsDialogController : Controller
    {
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
            
            product.DateAdded = DateTime.Now;
            if (uploadedImage != null && uploadedImage.ContentLength > 0)
            {
                using (BinaryReader reader = new BinaryReader(uploadedImage.InputStream))
                {
                    product.Picture = reader.ReadBytes(uploadedImage.ContentLength);
                }
            }
            using (GoodsContainer1 container = new GoodsContainer1())
            {

                product.SubCategory = container.SubCategorySet.FirstOrDefault(x => x.Id == product.SubCategory_Id);
                if (product.Article != null
                    && product.Name != null
                    && product.Picture != null
                    && product.Price != 0)
                {
                    container.ProductSet.Add(product);
                    container.SaveChanges();
                   
                    return PartialView("~/Views/AddProductsDialog/AddedProduct.cshtml",product);
                }
            }


            return RedirectToAction("AddProducts");

        }
        [HttpGet]
        public ActionResult AddDescriptionPatrameter(Product product, int categoryId)
        {
            product.DescriptionParameters.Add(new DescriptionParameters());
            GoodsContainer1 goods = new GoodsContainer1();
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet.Where(x => x.Category.Id == categoryId).ToList();
            return PartialView("~/Views/AddProductsDialog/AddProducts.cshtml", product);
        }
        [HttpGet]
        public ActionResult RemoveDescriptionParameter(Product product,string description,
            string descriptionParametr, int categoryId)
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
            ViewData["Categories"] = goods.CategorySet;
            ViewData["SubCategories"] = goods.SubCategorySet.Where(x => x.Category.Id == categoryId).ToList();
            return PartialView("~/Views/AddProductsDialog/AddProducts.cshtml", product);
        }
    }
}