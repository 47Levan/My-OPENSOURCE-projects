using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OnlineShop.Models.OnlineShopDatabase.Authentication;

namespace OnlineShop.Models.AccountOperations
{
    public interface IAccauntOperations
    {
        SignUp getSignUpFromUser(User user);
        User getUserFromSignUp(SignUp signUp, HttpPostedFileBase file);
        void EqualUser(User userToEqual, User equalUser);
    }
}
