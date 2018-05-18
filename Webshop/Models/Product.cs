using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class Product
    {
        public int Cena { get; set; }
        public string Naziv { get; set; }
       
        public int Id { get; set; }
        public Product(string n, int c,int id)
        {
            
            this.Cena = c;
            this.Naziv = n;
            this.Id = id;
        }
    }
}