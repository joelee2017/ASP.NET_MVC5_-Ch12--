using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 全新的_ASP.NET_Identity_2._0.Fliter
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if(filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = filterContext.HttpContext.User.Identity.GetUserId();
                var userManger = filterContext.HttpContext.GetOwinContext().
                    GetUserManager<ApplicationUserManager>();
                var currentUser = userManger.FindById(userId);
                if(currentUser.EmailConfirmed == false)
                {
                    //取得 URLHelper
                    var urlHelper = new UrlHelper(filterContext.RequestContext);

                    //將路徑名稱組合
                    var currentControllerAndActionName =
                        string.Concat(filterContext.RouteData.Values["controller"],
                        "_",
                        filterContext.RouteData.Values["action"]);

                    //明確開發[登入][登出][EMAIL驗證]
                    var allowAction = new[] { "Account_Login", "Account_LogOff", "Account_VerifyMail" };

                    if(allowAction.Contains(currentControllerAndActionName) ==
                        false)
                    {
                        //所有沒通過的 EMAIL 驗證都導向驗證頁面
                        var redirect = new RedirectResult(urlHelper.Action("VerifyMail", "Account"));
                        filterContext.Result = redirect;
                    }
                }
                    
            }
        }
    }
}