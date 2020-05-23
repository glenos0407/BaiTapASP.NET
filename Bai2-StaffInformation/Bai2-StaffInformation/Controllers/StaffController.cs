using Bai2_StaffInformation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;

namespace Bai2_StaffInformation.Controllers
{
    public class StaffController : Controller
    {  

        public ActionResult Open()
        {
            ViewBag.Files = Get_All_Files();

            if (Request["select_file"] == null) { return View(); }

            string file_path = Server.MapPath("~/Text/" + Request["select_file"]);
            string[] info = System.IO.File.ReadAllLines(file_path);
            Staff s = new Staff();

            s.StaffID = info[0];
            s.StaffName = info[1];
            CultureInfo culture = new CultureInfo("vi-VN");
            DateTime dateOfBirth = Convert.ToDateTime(info[2], culture);
            s.DateOfBirth = dateOfBirth;
            s.Salary = decimal.Parse (info[3]);
            s.StaffImage = info[4];

            ViewBag.ID = s.StaffID;
            ViewBag.StaffName = s.StaffName;
            ViewBag.DateofBirth = info[2];
            ViewBag.Salary = s.Salary;
            ViewBag.ImageSrc = "../../Imgs/" + s.StaffImage;

            return View();
        }

        public ActionResult Save()
        {
            ViewBag.Files = Get_All_Files();

            return View();
        }

        [HttpPost]
        public ActionResult Save(FormCollection f, HttpPostedFileBase fileImageUpload)
        {
            ViewBag.Files = Get_All_Files();

            if(fileImageUpload != null)
            {
                string img_path = Server.MapPath("~/Imgs/" + fileImageUpload.FileName);
                fileImageUpload.SaveAs(img_path);

                string info_path = Server.MapPath("~/Text/" + (f["txtID"]+".txt"));
                string[] info = { f["txtID"], f["txtName"], f["txtDateofBirth"], f["txtSalary"], fileImageUpload.FileName};

                System.IO.File.WriteAllLines(info_path, info);
            }

            return View();
        }

        private List<string> Get_All_Files()
        {  
            string path_files = Server.MapPath("~/Text/");
            string[] files = Directory.GetFiles(path_files,"*.txt");

            List<string> listFile = new List<string>();

            foreach (var item in files)
            {
                string[] temps = item.Split('\\');
                listFile.Add(temps[temps.Length - 1]);
            }

            return listFile;
        }
    }
}