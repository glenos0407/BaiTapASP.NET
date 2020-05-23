using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai6_DropdownList.Models
{
    public class Flower
    {
        public Flower(string name, string fileName)
        {
            Name = name;
            FileName = fileName;
        }

        public string Name { get; set; }
        public string FileName { get; set; }
    }
}