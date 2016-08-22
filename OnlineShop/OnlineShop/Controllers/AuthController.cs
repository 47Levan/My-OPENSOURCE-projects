using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models.Authentication;
namespace OnlineShop.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult SignIn(string ReturnUrl)
        {
            SignIn signIn = new SignIn()
            {
                returnUrl = ReturnUrl
            };
            return View(signIn);
        }
        [HttpPost]
        public ActionResult SignIn(SignIn model)
        {
            SignIn signIn = new SignIn()
            {
                
            };
            return View(signIn);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignIn model)
        {
            return View();
        }
    }
}