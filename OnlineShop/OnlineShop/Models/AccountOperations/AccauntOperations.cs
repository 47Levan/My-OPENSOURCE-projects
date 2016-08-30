using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using OnlineShop.Models.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
          
            user.PhoneNumber = signUp.PhoneNumber;
            if(signUp.Id!=null)
            {
                user.Id = signUp.Id;
                user.isModified = true;
                user.DateModified = DateTime.Now;
                savePicture(user,file,true);
            }
            else
            {
                user.DateAdded = DateTime.Now;
                savePicture(user, file,false);
            }
         
            return user;
        }
        private void savePicture(User user,HttpPostedFileBase file,bool ismodify)
        {
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
            else
            {
                if(ismodify)
                {
                    UserManager<User> userManager = new UserManager<User>(
          new UserStore<User>(new AuthDBContext()));
                    user.Picture = userManager.Users.FirstOrDefault(x=>x.Id==user.Id).Picture;
                }
            }
        }
        public SignUp getSignUpFromUser(User user)
        {
            SignUp signUp = new SignUp();
            signUp.UserName = user.UserName;
            signUp.EmailAdress = user.Email;
            signUp.FirstName = user.Name;
            signUp.SecondName = user.SecondName;
            signUp.Age = user.Age!=null? (int)user.Age : 0;
            signUp.Country = user.Country;
            signUp.PhoneNumber = user.PhoneNumber;
            signUp.Id = user.Id;
            return signUp;
        }
        public void EqualUser(User userToEqual,User equalUser)
        {
            userToEqual.Name = equalUser.Name;
            userToEqual.SecondName = equalUser.SecondName;
            userToEqual.Age = equalUser.Age;
            userToEqual.Country = equalUser.Country;
            userToEqual.DateModified = equalUser.DateModified;
            userToEqual.isModified = true;
            userToEqual.UserName = equalUser.UserName;
            userToEqual.PhoneNumber = equalUser.PhoneNumber;
            userToEqual.Email = equalUser.Email;
        }
    }
}
