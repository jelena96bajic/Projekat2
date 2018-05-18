using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Products products = (Products)HttpContext.Application["products"];

            ViewBag.products = products;
            return View();
        }

      
    }
}