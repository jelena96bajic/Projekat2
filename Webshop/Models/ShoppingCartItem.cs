using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class ShoppingCartItem
    {
        public int Kolicina { get; set; }
        public Product Proizvod { get; set; }
        public int Total {

            get {

               
                
                return Kolicina * Proizvod.Cena; ;
            }

           
            

        }
        public ShoppingCartItem() {


        }

        public ShoppingCartItem(Product p, int k)
        {
            this.Kolicina = k;
            this.Proizvod = p;
        }
    }
}