using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Models;
namespace OnlineShop.Models
{
    class ProductOperations :IProductOperations
    {
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
    }
}
