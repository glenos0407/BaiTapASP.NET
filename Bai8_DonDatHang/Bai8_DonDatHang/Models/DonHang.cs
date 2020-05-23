using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai8_DonDatHang.Models
{
    public class DonHang
    {
        public  DonHang() { }

        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}