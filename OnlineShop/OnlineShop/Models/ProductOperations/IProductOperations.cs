using System.Web;
using System.Collections.Generic;
namespace OnlineShop.Models
{
    public interface IProductOperations
    {
        List<Product> sortProducts(int? category, string orderType);
        List<Product> calcForProductsByFilter(int? subCategory);
        Product postAddProduct(Product product, HttpPostedFileBase file);
    }
}
