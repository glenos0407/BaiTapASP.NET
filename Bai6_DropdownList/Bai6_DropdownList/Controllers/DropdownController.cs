using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai6_DropdownList.Models;

namespace Bai6_DropdownList.Controllers
{
    public class DropdownController : Controller
    {
       
        public ActionResult Index() 
        {
            List<Flower> flowers = new List<Flower>();

            flowers.Add(new Flower("Hoa 01", "01.jpg"));
            flowers.Add(new Flower("Hoa 02", "02.jpg"));
            flowers.Add(new Flower("Hoa 03", "03.jpg"));
            flowers.Add(new Flower("Hoa 04", "04.jpg"));
            flowers.Add(new Flower("Hoa 05", "05.jpg"));

            ViewBag.Flowers = flowers;
            Session["default"] = "01.jpg";

            return View();
        }
    }
}