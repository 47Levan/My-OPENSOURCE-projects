using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace OnlineShop.Models
{
    class ProductOperations :IProductOperations
    {
        private HttpServerUtilityBase Server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
        public List<Product> sortProducts(int? category,string orderType)
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
        public List<Product> calcForProductsByFilter(int? subCategory)
        {
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
            return products;
        }
        public Product postAddProduct(Product product, HttpPostedFileBase file)
        {
            using (GoodsContainer1 goods = new GoodsContainer1())
            {
                product.DateAdded = DateTime.Now;
                string pathToSave;
                string serverPathToSave = $"~/Images/Products/" +
$"{goods.CategorySet.FirstOrDefault(x => x.Id == goods.SubCategorySet.FirstOrDefault(y => y.Id == product.SubCategory_Id).CategoryId).category}/" +
$"{goods.SubCategorySet.FirstOrDefault(x => x.Id == product.SubCategory_Id).Subcategory}" +
$"/{file.FileName}";
                pathToSave = Server.MapPath(serverPathToSave);

                string folderToCreate = $@"~/Images/Products/" +
$"{goods.CategorySet.FirstOrDefault(x => x.Id == goods.SubCategorySet.FirstOrDefault(y => y.Id == product.SubCategory_Id).CategoryId).category}/" +
$"{goods.SubCategorySet.FirstOrDefault(x => x.Id == product.SubCategory_Id).Subcategory}";
                if (!Directory.Exists(folderToCreate))
                {

                    Directory.CreateDirectory(Server.MapPath(folderToCreate));
                }
                file.SaveAs(pathToSave);
                product.Picture = serverPathToSave;
                product.SubCategory = goods.SubCategorySet.FirstOrDefault(x => x.Id == product.SubCategory_Id);
                goods.ProductSet.Add(product);
                goods.SaveChanges();
                return  product;
            }
        }
    }
}
