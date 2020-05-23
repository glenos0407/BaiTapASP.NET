using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.WebSockets;
using System.Xml;
using System.Xml.Linq;
using Bai9_QLThongTinSV.Models;

namespace Bai9_QLThongTinSV.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View(XML_to_Student());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student sv, HttpPostedFileBase imageUpload)
        {
            string img_path = Server.MapPath("~/Imgs/" + imageUpload.FileName);
            imageUpload.SaveAs(img_path);

            sv.Avatar = imageUpload.FileName;

            if (!Create_Student(sv)) { 
                ViewBag.Message = "ID Tồn Tại !";
                return View();
            }

            return RedirectToAction("Index", XML_to_Student());
        }

        
        public ActionResult Edit(int id) {
            return View(Search_Student(id)); 
        }

        [HttpPost]
        public ActionResult Edit(Student sv, HttpPostedFileBase imageUpload)
        {
            if(imageUpload != null)
            {
                string img_path = Server.MapPath("~/Imgs/" + imageUpload.FileName);
                imageUpload.SaveAs(img_path);

                sv.Avatar = imageUpload.FileName;
            }

            Edit_Student(sv);

            return RedirectToAction("Index", XML_to_Student());
        }

        public ActionResult Details(int id) { 
            return View(Search_Student(id));
        }

        public ActionResult Delete(int id) { 
            return View(Search_Student(id)); 
        }

        [HttpPost]
        public ActionResult DeleteAccept(int id)
        {
            Delete_Student(id);
            return RedirectToAction("Index", XML_to_Student());
        }

        private List<Student> XML_to_Student()
        {
            string path_fXMl = Server.MapPath("~/XML/Students.xml");
            List<Student> students = new List<Student>();

            //Doc File XML
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path_fXMl);

            //Get Node Student
            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                Student st = new Student();
                st.StudentID = int.Parse(node.Attributes[0].InnerText);

                foreach (XmlNode chid in node.ChildNodes)
                {
                    switch (chid.Name)
                    {
                        case "FullName":
                            st.FullName = chid.InnerText;
                            break;
                        case "DateOfBirth":
                            st.DateOfBirth = (Convert.ToDateTime(chid.InnerText));
                            break;
                        case "Avatar":
                            st.Avatar = chid.InnerText;
                            break;
                    };
                }

                students.Add(st);
            }

            return students;
        }

        private Boolean Create_Student(Student student)
        {
            string path_fXMl = Server.MapPath("~/XML/Students.xml");

            if (Search_Student(student.StudentID) != null) { return false; }

            //Doc File XML
            XDocument xmlDoc = XDocument.Load(path_fXMl);

            XAttribute idAttribute = new XAttribute("id", student.StudentID);
            XElement fullNameElement = new XElement("FullName", student.FullName);
            XElement dateOfBirthElement = new XElement("DateOfBirth", student.DateOfBirth.ToString("d"));
            XElement avatarElement = new XElement("Avatar", student.Avatar);

            xmlDoc.Element("students").Add(new XElement("student", idAttribute , fullNameElement, dateOfBirthElement, avatarElement));

            xmlDoc.Save(path_fXMl);

            return true;
        }

        private Student Search_Student(int id)
        {
            string path_fXMl = Server.MapPath("~/XML/Students.xml");

            //Doc File XML
            XDocument xmlDoc = XDocument.Load(path_fXMl);
            var xElement = xmlDoc.Element("students").Elements("student").Where(element => element.Attribute("id").Value.Equals(id.ToString())).FirstOrDefault();

            if(xElement == null) { return null; }

            Student student = new Student();

            student.StudentID = Convert.ToInt32(xElement.Attribute("id").Value);
            student.FullName = xElement.Element("FullName").Value;
            student.DateOfBirth = Convert.ToDateTime(xElement.Element("DateOfBirth").Value);
            student.Avatar = xElement.Element("Avatar").Value;

            return student;
        }

        private void Edit_Student(Student student)
        {
            string path_fXMl = Server.MapPath("~/XML/Students.xml");

            //Doc File XML
            XDocument xmlDoc = XDocument.Load(path_fXMl);
            var xElement = xmlDoc.Element("students").Elements("student").Where(element => element.Attribute("id").Value.Equals(student.StudentID.ToString())).FirstOrDefault();

            if(xElement != null)
            {
                if(student.StudentID != null)
                {
                    xElement.SetAttributeValue("id", student.StudentID);
                }

                if (!student.FullName.Trim().Equals(""))
                {
                    xElement.SetElementValue("FullName", student.FullName);
                }

                if (student.DateOfBirth != null)
                {
                    xElement.SetElementValue("DateOfBirth", student.DateOfBirth.ToString("d"));
                }

                if (!student.Avatar.Trim().Equals(""))
                {
                    xElement.SetElementValue("Avatar", student.Avatar);
                } 
            }

            xmlDoc.Save(path_fXMl);
        }

        private void Delete_Student(int id)
        {
            string path_fXMl = Server.MapPath("~/XML/Students.xml");

            //Doc File XML
            XDocument xmlDoc = XDocument.Load(path_fXMl);
            var xElement = xmlDoc.Element("students").Elements("student").Where(element => element.Attribute("id").Value.Equals(id.ToString())).FirstOrDefault();

            if(xElement != null)
            {
                xElement.Remove();
                xmlDoc.Save(path_fXMl);
            }
        }
    }
}