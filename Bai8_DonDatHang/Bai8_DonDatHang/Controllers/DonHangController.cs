using Bai8_DonDatHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Bai8_DonDatHang.Controllers
{
    public class DonHangController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateOrder(IEnumerable<DonHang> donHangs)
        {
            DonHang dh = new DonHang();
            dh = donHangs.ToList()[0];

            string info_path = Server.MapPath("~/Texts/DonHang.txt");
            List<string> infors = new List<string>();

            infors.Add(dh.HoTen);
            infors.Add(dh.DiaChi);
            infors.Add(dh.MaSoThue);

            foreach (SanPham sp in donHangs.ToList()[0].sanPhams)
            {
                infors.Add(sp.TenSanPham);
                infors.Add(sp.SoLuong.ToString());
            }

            string[] info = infors.ToArray();

            System.IO.File.WriteAllLines(info_path, info);

            return Json(data: "OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Review()
        {
            string info_path = Server.MapPath("~/Texts/DonHang.txt");
            string[] info = System.IO.File.ReadAllLines(info_path);

            DonHang dh = new DonHang();
            List<SanPham> sanPhams = new List<SanPham>();

            dh.HoTen = info[0];
            dh.DiaChi = info[1];
            dh.MaSoThue = info[2];


            int i = 3;

            while(i < info.Length)
            {
                if(i > info.Length) { break; }
               
                SanPham sp = new SanPham();

                sp.TenSanPham = info[i];
                sp.SoLuong = int.Parse(info[i + 1].Trim());

                sanPhams.Add(sp);

                i = i + 2;
            }

            ViewBag.KhachHang = dh.HoTen;
            ViewBag.DiaChi = dh.DiaChi;
            ViewBag.MaSoThue = dh.MaSoThue;
            ViewBag.SanPhams = sanPhams;

            return View();
        }
    }
}