using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> list;
        public int Total{

            get{

                int ukupno = 0;
                foreach (ShoppingCartItem sh in list) {

                    ukupno += sh.Total;
                   
                        }

                return ukupno;
            }
        }

        public void Add(ShoppingCartItem sh)
        {
            list.Add(sh);
        }
        public ShoppingCart() {

            list = new List<ShoppingCartItem>();
        }

        public static ShoppingCart Current
        {
            get
            {
                var cart = HttpContext.Current.Session["sc"] as ShoppingCart;
                if (null == cart)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["sc"] = cart;
                }
                return cart;
            }
        }

    }
}