using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai7_YKienNguoiDung.Models
{
    public class Product
    {
        public  Product(string name) { Name = name; }
        public string Name { get; set; }
    }
}