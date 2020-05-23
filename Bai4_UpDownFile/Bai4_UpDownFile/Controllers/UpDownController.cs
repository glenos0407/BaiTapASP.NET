using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai4_UpDownFile.Controllers
{
    public class UpDownController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Down(HttpPostedFileBase ImageUploadFile)
        {
            if(ImageUploadFile != null)
            {
                string pathImg = Server.MapPath("~/Imgs/" + ImageUploadFile.FileName);
                ImageUploadFile.SaveAs(pathImg);
                ViewBag.Image = ImageUploadFile.FileName;
            }

            return View();
        }

        [HttpPost]
        public FileResult Download_File(string name)
        {
            string pathImg = Server.MapPath("~/Imgs/" + name);

            return File(pathImg, "application/force- download", Path.GetFileName(pathImg));
        }
    }
}