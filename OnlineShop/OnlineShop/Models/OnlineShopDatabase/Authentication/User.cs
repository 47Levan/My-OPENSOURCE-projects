using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Models.OnlineShopDatabase.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.OnlineShopDatabase.Authentication
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Country { get; set; }
        public int? Age { get; set; }
        public string Picture { get; set; }
        public bool isModified { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
