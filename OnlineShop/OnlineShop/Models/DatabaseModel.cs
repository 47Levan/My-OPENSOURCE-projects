using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
     public class DatabaseModel
    {
        public virtual List<Category> Categories { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
