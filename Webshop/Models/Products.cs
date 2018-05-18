using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Webshop.Models
{
    public class Products
    {
        public Dictionary<int,Product> list;

        public Products(string path)
        {
            path = HostingEnvironment.MapPath(path);
            list = new Dictionary<int, Product>();
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Product p = new Product(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[0]));
                list.Add(p.Id,p);

            }
            sr.Close();
            fs.Close();
;        }
        
    }
}