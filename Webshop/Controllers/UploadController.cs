using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            List<UploadFile> list = (List<UploadFile>)Session["list"];

            if (list == null)
            {

                list = new List<UploadFile>();
                Session["list"] = list;
            }
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            List<UploadFile> list = (List<UploadFile>)Session["list"];

            if (list == null)
            {

                list = new List<UploadFile>();
                Session["list"] = list;
            }

            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var name = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), name);

                        file.SaveAs(path);
                        UploadFile uploadFile = new UploadFile(name, path);
                        list.Add(uploadFile);

                    }

                }


            }
            ViewBag.uploadedFiles = list;
            return View("Index");

        }
    }
}