using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class UploadFile
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public UploadFile(string n, string p)
        {
            Name = n;
            Path = p;

        }
    }
}