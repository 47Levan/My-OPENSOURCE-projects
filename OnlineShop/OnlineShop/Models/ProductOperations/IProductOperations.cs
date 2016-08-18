using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public interface IProductOperations
    {
        List<Product> sortProducts(int? category, string orderType);
        List<Product> calcForProductsByFilter(int? subCategory);
    }
}
