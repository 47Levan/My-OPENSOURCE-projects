using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using OnlineShop.Models.Authentication;
namespace OnlineShop.Models.AccountOperations
{
    class AccauntOperations :IAccauntOperations
    {
        private HttpServerUtilityBase Server = new HttpServerUtilityWrapper(HttpContext.Current.Server);
        public User getUserFromSignUp(SignUp signUp, HttpPostedFileBase file)
        {
            User user = new User();
            user.UserName = signUp.UserName;
            user.Email = signUp.EmailAdress;  
            user.Name = signUp.FirstName;
            user.SecondName = signUp.SecondName;
            user.Age = signUp.Age;
            user.Country = signUp.Country;
            user.DateAdded = DateTime.Now;
            user.PhoneNumber = signUp.PhoneNumber;
            if (file != null)
            {
                string pathToSave;
                string serverPathToSave = $"~/Images/Accaunts/Users" + $"/{file.FileName}";
                pathToSave = Server.MapPath(serverPathToSave);

                string folderToCreate = $@"~/Images/Accaunts/Users";
                if (!Directory.Exists(folderToCreate))
                {

                    Directory.CreateDirectory(Server.MapPath(folderToCreate));
                }
                file.SaveAs(pathToSave);
                user.Picture = serverPathToSave;
            }
            return user;
        }
    }
}
