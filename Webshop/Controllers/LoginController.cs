using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class LoginController : Controller
    {
        public static List<MyUser> korisnici = new List<MyUser>();
        // GET: Login
        public ActionResult Index()
        {
            MyUser user = (MyUser)Session["User"];
            if (user == null)
            {
                user = new MyUser();
                Session["User"] = user;
            }
            ViewBag.user = user;
            return View();
        }

        [HttpPost]
        // POST: Login/SignInBasic
        public ActionResult SignInBasic()
        {
            MyUser user = (MyUser)Session["User"];
            if (user == null)
            {
                user = new MyUser();
                Session["User"] = user;
            }
            if (Request["username"].Equals("pera") && Request["password"].Equals("pera"))
            {
                user.Username = Request["username"];
                user.Password = Request["password"];
                
            }
            ViewBag.user = user;
            // Pređi na Login/Result.cshtml View
            return View("Result"); // Da smo vratili View(), otišao bi na: Login/SignIn.cshtml, a to nemamo.
        }
    }
}