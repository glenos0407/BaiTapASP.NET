using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai7_YKienNguoiDung.Models;

namespace Bai7_YKienNguoiDung.Controllers
{
    public class OpinionController : Controller
    {

        public ActionResult Index() { return View(); }

        [HttpPost]
        public ActionResult Index(FormCollection frmCollection)
        {
            string selected = frmCollection["product"];

            string opinion1 = frmCollection["vote1"];
            string opinion2 = frmCollection["vote2"];
            string opinion3 = frmCollection["vote3"];

            List<string> opinions = new List<string>();

            if(opinion1 != null)
            {
                opinions.Add(opinion1);
            }
            if (opinion2 != null)
            {
                opinions.Add(opinion2);
            }
            if (opinion3 != null)
            {
                opinions.Add(opinion3);
            }

            ViewBag.Selected = selected;
            ViewBag.Votes = opinions;

            return View();
        }

        
    }
}