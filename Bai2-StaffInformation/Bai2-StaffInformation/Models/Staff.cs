using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai2_StaffInformation.Models
{
    public class Staff
    {
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string StaffImage { get; set; }
    }
}