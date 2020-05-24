using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai10_QLSanPham.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}