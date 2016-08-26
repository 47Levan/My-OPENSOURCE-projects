using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OnlineShop.Models.Authentication;
namespace OnlineShop.Models.AccountOperations
{
    public interface IAccauntOperations
    {
        User getUserFromSignUp(SignUp signUp, HttpPostedFileBase file);
    }
}
