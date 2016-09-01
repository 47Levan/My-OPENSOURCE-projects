using System;
using System.Web;
using System.Collections.Generic;
using OnlineShop.Models.OnlineShopDatabase.Goods;

namespace OnlineShop.Models
{
    public interface IProductOperations
    {
        List<Product> sortProducts(Guid? category, string orderType);
        List<Product> calcForProductsByFilter(Guid? subCategory);
        Product postAddProduct(Product product, HttpPostedFileBase file);
    }
}
