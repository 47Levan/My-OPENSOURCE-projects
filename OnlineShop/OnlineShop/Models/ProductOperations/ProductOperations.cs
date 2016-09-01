using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OnlineShop.Models.OnlineShopDatabase;
using OnlineShop.Models.OnlineShopDatabase.Goods;

namespace OnlineShop.Models
{
    class ProductOperations :IProductOperations
    {
        private HttpServerUtilityBase Server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
        public List<Product> sortProducts(Guid? category,string orderType)
        {
            List<Product> products = new List<Product>();
            OnlineShopDbContext goods = new OnlineShopDbContext();
            if (category == null)
            {
                switch (orderType)
                {
                    case "from cheap to expensive":
                        products = goods.Products.OrderBy(x => x.Price).ToList();
                        break;
                    case "from expensive to cheap":
                        products = goods.Products.OrderByDescending(x => x.Price).ToList();
                        break;
                    case "Newest":
                        products = goods.Products.OrderByDescending(x => x.DateAdded).ToList();
                        break;
                    case "Oldest":
                        products = goods.Products.OrderBy(x => x.DateAdded).ToList();
                        break;
                }
            }
            else
            {
                switch (orderType)
                {
                    case "from cheap to expensive":
                        products = goods.Products.Where(x => x.SubCategory_Id == category).OrderBy(x => x.Price).ToList();
                        break;
                    case "from expensive to cheap":
                        products = goods.Products.Where(x => x.SubCategory_Id == category).OrderByDescending(x => x.Price).ToList();
                        break;
                    case "Newest":
                        products = goods.Products.Where(x => x.SubCategory_Id == category).OrderByDescending(x => x.DateAdded).ToList();
                        break;
                    case "Oldest":
                        products = goods.Products.Where(x => x.SubCategory_Id == category).OrderBy(x => x.DateAdded).ToList();
                        break;
                }
            }
            return products;
        }
        public List<Product> calcForProductsByFilter(Guid? subCategory)
        {
            OnlineShopDbContext goods = new OnlineShopDbContext();
            List<Product> products = new List<Product>();
            if (subCategory != null)
            {
                products = goods.Products.Where(x => x.SubCategory.Id == subCategory).ToList();
            }
            else
            {
                products = goods.Products.ToList();
            }
            return products;
        }
        public Product postAddProduct(Product product, HttpPostedFileBase file)
        {
            using (OnlineShopDbContext goods = new OnlineShopDbContext())
            {
                product.DateAdded = DateTime.Now;
                string pathToSave;
                string serverPathToSave = $"~/Images/Products/" +
$"{goods.Categories.FirstOrDefault(x => x.Id == goods.SubCategories.FirstOrDefault(y => y.Id == product.SubCategory_Id).Category_Id).category}/" +
$"{goods.SubCategories.FirstOrDefault(x => x.Id == product.SubCategory_Id).Subcategory}" +
$"/{file.FileName}";
                pathToSave = Server.MapPath(serverPathToSave);

                string folderToCreate = $@"~/Images/Products/" +
$"{goods.Categories.FirstOrDefault(x => x.Id == goods.SubCategories.FirstOrDefault(y => y.Id == product.SubCategory_Id).Category_Id).category}/" +
$"{goods.SubCategories.FirstOrDefault(x => x.Id == product.SubCategory_Id).Subcategory}";
                if (!Directory.Exists(folderToCreate))
                {

                    Directory.CreateDirectory(Server.MapPath(folderToCreate));
                }
                file.SaveAs(pathToSave);
                product.Picture = serverPathToSave;
                product.SubCategory = goods.SubCategories.FirstOrDefault(x => x.Id == product.SubCategory_Id);
                goods.Products.Add(product);
                goods.SaveChanges();
                return  product;
            }
        }
    }
}
