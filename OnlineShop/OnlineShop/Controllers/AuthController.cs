using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineShop.Models.AccountOperations;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using OnlineShop.Models.OnlineShopDatabase.Authentication;
using OnlineShop.Models.OnlineShopDatabase;
namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private static readonly UserStore<User> userStore = new UserStore<User>(new OnlineShopDbContext());
        private readonly UserManager<User> userManager = new UserManager<User>(userStore);
        private IAccauntOperations acc;
        public AuthController(IAccauntOperations userAcc)
        {
            acc = userAcc;
        }
        public AuthController(UserManager<User> manager)
        {
            userManager = manager;
        }
   
        // GET: Auth
        [HttpPost]
        public ActionResult StartSignIn(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;           
            return View("~/Views/Auth/SignIn.cshtml");
        }
        [HttpGet]
        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View("~/Views/Auth/SignIn.cshtml");
        }
        [HttpPost]
        public async Task<ActionResult> SignIn(SignIn model,string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user = await userManager.FindAsync(model.UserName,model.Password);
            if(user !=null)
            {
                await SignIn(user);
                return Redirect(returnUrl);
            }
            ModelState.AddModelError("","Invalid email or password");
            return View();
        }
        [HttpGet]
        public ActionResult SignOut(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            SignOut();
            return Redirect(returnUrl);
        }
        [HttpGet]
        public ActionResult SignUp(string returnUrl)
        {         
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SignUp(SignUp model, HttpPostedFileBase uploadedImage, string returnUrl)
        {
            if (model.UserName == null && model.EmailAdress == null && model.Password == null)
            {
                return View();
            }
            User user = acc.getUserFromSignUp(model, uploadedImage);
            var result = await userManager.CreateAsync(user, model.Password);
            userManager.AddToRole(user.Id, "User");
            if (result.Succeeded)
            {
                await SignIn(user);
                return Redirect(returnUrl);
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> ShowUserProfile()
        {
            User user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                return View(user);
            }          
               return RedirectToAction("Index","MainPage");         
        }
       
        [HttpGet]
        public ActionResult ShowAccaunts()
        {
            return PartialView(userManager.Users.ToList());
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            SignUp signUp = acc.getSignUpFromUser(user);
            return PartialView(signUp);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeProfile(SignUp signUp,HttpPostedFileBase uploadedImage)
        {
           
            User user =acc.getUserFromSignUp(signUp,uploadedImage);
            User userToUpdate = userManager.FindById(signUp.Id);
            acc.EqualUser(userToUpdate,user);
            IdentityResult result = await userManager.UpdateAsync(userToUpdate);
            if (result.Succeeded)
            {
                await   userStore.Context.SaveChangesAsync();
                return  PartialView("~/Views/Auth/ShowOneUser.cshtml",userToUpdate);
            }
            return PartialView("~/Views/Auth/EditProfile.cshtml", signUp);
        }
        public async Task SignIn(User user)
        {
            ClaimsIdentity identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);
            GetSignInManager().SignIn(identity);
        }
        public IAuthenticationManager GetSignInManager()
        {
            IOwinContext ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }
        public void SignOut()
        {
            GetSignInManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
      
    }
}