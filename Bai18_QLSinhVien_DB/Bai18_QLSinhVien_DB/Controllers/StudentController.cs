using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Entity;

namespace Bai18_QLSinhVien_DB.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Student()
        {
            Student_DAL student_DAL = new Student_DAL();

            return View(student_DAL.GetStudents());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Student_DAL student_DAL = new Student_DAL();

            return View(student_DAL.GetStudent_Ent(id));
        }

        public ActionResult Detail(int id)
        {
            Student_DAL student_DAL = new Student_DAL();

            return View(student_DAL.GetStudent_Ent(id));
        }

        public ActionResult Delete(int id)
        {
            Student_DAL student_DAL = new Student_DAL();

            return View(student_DAL.GetStudent_Ent(id));
        }

        [HttpPost]
        public ActionResult Delete_Accept(int id)
        {
            Student_DAL student_DAL = new Student_DAL();

            if (!(student_DAL.Delete(id)))
            {
                ViewBag.Message = "Có Lỗi Xảy Ra !";
                return View("Delete", id);
            }

            return RedirectToAction("Student", "Student");
        }

        [HttpPost]
        public ActionResult Create(Student_Ent stu_ent)
        {
            Student_DAL student_DAL = new Student_DAL();

            if (!(student_DAL.Check_Exist(stu_ent.StudentID)))
            {
                ViewBag.Message = "ID Tồn Tại !";
                return View();
            }

            if (!(student_DAL.Add(stu_ent)))
            {
                ViewBag.Message = "Có Lỗi Xảy Ra !";
                return View();
            }

            return RedirectToAction("Student", "Student");
        }

        [HttpPost]
        public ActionResult Edit(Student_Ent stu_ent)
        {
            if (ModelState.IsValid)
            {
                Student_DAL student_DAL = new Student_DAL();

                if (!(student_DAL.Edit(stu_ent)))
                {
                    ViewBag.Message = "Có Lỗi Xảy Ra !";
                    return View();
                }
            }

            return RedirectToAction("Student", "Student");
        }
    }
}