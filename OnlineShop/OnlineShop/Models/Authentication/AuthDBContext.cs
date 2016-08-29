using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
namespace OnlineShop.Models.Authentication
{
    public class AuthDBContext :IdentityDbContext<User>
    {
        public AuthDBContext() :base("OnlineShopAuth")
        {

        }
    }
}
