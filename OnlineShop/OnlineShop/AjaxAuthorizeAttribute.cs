using System.Web;
using System.Web.Mvc;

namespace OnlineShop
{
    public class AjaxAuthorizeAttribute: AuthorizeAttribute
    {
        
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                var urlHelper = new UrlHelper();
                context.HttpContext.Response.StatusCode = 403;
                context.Result = new JsonResult
                {
                    Data = new
                    {
                        Error = "NonAuthorized",
                        LogOnUrl = urlHelper.Action("SignIn", "Auth")
                    }
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(context);
            }
        }
    }
}
