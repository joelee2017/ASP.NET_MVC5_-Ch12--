using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 使用_Session_做身份驗證.Filters;

namespace 使用_Session_做身份驗證.Controllers
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

        public ActionResult Login()
        {
            Session["auth"] = true;
            return RedirectToAction("Contact");
        }

        public ActionResult Logout()
        {
            Session["auth"] = false;
            return RedirectToAction("Index");
        }

        [AuthorizePlus]
        public ActionResult Backend()
        {
            return RedirectToAction("Contact");
        }
    }
}