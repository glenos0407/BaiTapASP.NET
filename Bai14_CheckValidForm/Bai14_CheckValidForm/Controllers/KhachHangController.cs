using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai14_CheckValidForm.Controllers
{
    public class KhachHangController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Bai14_CheckValidForm.Models.KhachHang khachHang, HttpPostedFileBase fImage)
        {
            khachHang.Image = fImage.FileName;

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Successfully !";
                return View();
            }

            ViewBag.Message = "";

            return View();
        }
    }
}