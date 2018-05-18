using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public static List<MyUser> korisnici = new List<MyUser>();
        public ActionResult Index()
        {
            ShoppingCart sc = (ShoppingCart)Session["sc"];

            MyUser m = new MyUser();
            if (m.Username != Request["username"])
            {
                
                if (sc == null)
                {
                    sc = new ShoppingCart();
                    Session["sc"] = sc;
                }
              
            }
            ViewBag.sc = sc;
            // Pređi na ShoppingCart/Index.cshtml View
            return View();

        }
        [HttpPost]
        // POST: ShoppingCart/Add
        public ActionResult Add(ShoppingCartFormParam item)
        {
            Products products = (Products)HttpContext.Application["products"];
            ShoppingCart sc = (ShoppingCart)Session["sc"];
            if (sc == null)
            {
                sc = new ShoppingCart();
                Session["sc"] = sc;
            }

            if (!item.id.Equals("") && !item.cound.Equals(""))
            {
                item.id = int.Parse(Request["id"]);
                item.cound = int.Parse(Request["cound"]);

                sc.Add(new ShoppingCartItem(products.list[item.id], item.cound));
            }
            ViewBag.sc = sc;
            // Pređi na ShoppingCart/Index.cshtml View
            return View("Index"); // Da smo vratili View(), otišao bi na: ShoppingCart/Add.cshtml, a to nemamo.
        }
        public ActionResult Zavrsi()
        {
            
            Session.Abandon();
            ShoppingCart sc = new ShoppingCart();
            MyUser myUser = new MyUser();

            Session["user"] = myUser;
            Session["sc"] = sc;
            ViewBag.sc = sc; //u isti (kao u prethodnoj fji smestamo novi objekat)
            ViewBag.user = User;
            return View("Add");
        }

       
    }
}