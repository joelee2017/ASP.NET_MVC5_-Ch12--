using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace 使用__Forms_Authentication__做身份驗證.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // FormsAuthenticationTicke 身份驗證
        //另需在 Web.Config 設定
        //<system.web>
        //<authentication mode = "Forms" >
        //< forms loginUrl="~/ " timeout="2880"/>
        //</authentication>
        [HttpPost]
        public ActionResult Login(string account, string  password)
        {
            if(account == "mvc" && password == "123456")
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    //你想要存放在 Suser.Identy.Name 的值，通常是使用者帳號
                    account,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    true,//將管理者登入的 Cookie 設定成 Session Cookie
                    "userdata9527", // userdata 資料
                    FormsAuthentication.FormsCookiePath);

                string encTicket = FormsAuthentication.Encrypt(ticket);

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                cookie.HttpOnly = true;

                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("index");
        }

        [Authorize]
        public ActionResult test()
        {
            return Content("登入成功");
        }
    }
}