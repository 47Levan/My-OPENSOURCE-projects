using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models.Authentication;
using Microsoft.AspNet.Identity;
using OnlineShop.Models.AccountOperations;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin;
namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager = new UserManager<User>(
          new UserStore<User>(new AuthDBContext()));
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
        public ActionResult startSignIn(string returnUrl)
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
        [HttpGet]
        public async Task<ActionResult> showUserProfile()
        {
            AuthDBContext auth = new AuthDBContext();
            User user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                return View(user);
            }          
               return RedirectToAction("Index","MainPage");         
        }
        [HttpPost]
        public async Task<ActionResult> SignUp(SignUp model,HttpPostedFileBase uploadedImage, string returnUrl)
        {          
            if(model.UserName==null && model.EmailAdress == null && model.Password == null)
            {
                return View();
            }
            User user = acc.getUserFromSignUp(model, uploadedImage);
            var result = await userManager.CreateAsync(user,model.Password);
            userManager.AddToRole(user.Id,"User");          
            if (result.Succeeded)
            {
                await SignIn(user);
                return Redirect(returnUrl);
            }
            return View();
        }
        [HttpGet]
        public ActionResult ShowAccaunts()
        {
            return PartialView(userManager.Users.ToList());
        }
        [HttpGet]
        public ActionResult EditProfile(User user)
        {
            return PartialView();
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