using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Entity;

namespace Bai18_QLSinhVien_DB.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Course()
        {
            Course_DAL course_DAL = new Course_DAL();

            return View(course_DAL.GetCourses());
        }

        public ActionResult Create()
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();
            ViewBag.Teachers = teacher_DAL.GetTeachers();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Course_Ent course_Ent, string TeacherName)
        {
            Course_DAL course_DAL = new Course_DAL();
            //Teacher_DAL teacher_DAL = new Teacher_DAL();
            
            if (!course_DAL.Check_Exist(course_Ent.CourseID))
            {
                Teacher_DAL teacher_DAL = new Teacher_DAL();
                ViewBag.Teachers = teacher_DAL.GetTeachers();
                ViewBag.Message = "ID Tồn Tại !";
                return View();
            }

            Teacher_Ent teacher = new Teacher_Ent();
            teacher.TeacherID = int.Parse(TeacherName);
            //teacher.TeacherName = teacher_DAL.GetName(teacher.TeacherID);

            course_Ent.Teacher = teacher;

            if (!(course_DAL.Add_Course(course_Ent)))
            {
                Teacher_DAL teacher_DAL = new Teacher_DAL();
                ViewBag.Teachers = teacher_DAL.GetTeachers();
                ViewBag.Message = "Có Lỗi Xảy Ra !";
                return View();
            }

            return RedirectToAction("Course", "Course");
        }

        public ActionResult Register()
        {
            Course_DAL course_DAL = new Course_DAL();
            ViewBag.Courses = course_DAL.GetCourses();

            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection frmController)
        {
            Course_DAL course_DAL = new Course_DAL();
            Student_DAL student_DAL = new Student_DAL();
            int id_course = int.Parse(frmController["CourseName"]);
            string student_name = frmController["txtStudentName"];

            Student_Ent student_Ent = new Student_Ent();
            student_Ent.StudentName = student_name;

            //Add Student to SQL
            if (!(student_DAL.Add(student_Ent)))
            {
                ViewBag.Courses = course_DAL.GetCourses();
                ViewBag.Message = "Có Lỗi Xảy Ra !";

                return View();
            }

            int id_student = student_DAL.GetID_byName(student_name);

            if(!course_DAL.Add_Register(id_course, id_student))
            {
                ViewBag.Courses = course_DAL.GetCourses();
                ViewBag.Message = "Có Lỗi Xảy Ra !";

                return View();
            }

            ViewBag.Courses = course_DAL.GetCourses();
            ViewBag.Message = "Successfully !";
            return View();
        }

        public ActionResult Edit(int id)
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();
            ViewBag.Teachers = teacher_DAL.GetTeachers();

            Course_DAL course_DAL = new Course_DAL();

            return View(course_DAL.GetCourse_Ent(id));
        }

        [HttpPost]
        public ActionResult Edit(Course_Ent course_Ent, string TeacherName)
        {
            Course_DAL course_DAL = new Course_DAL();
            //Teacher_DAL teacher_DAL = new Teacher_DAL();

            Teacher_Ent teacher = new Teacher_Ent();
            teacher.TeacherID = int.Parse(TeacherName);
            //teacher.TeacherName = teacher_DAL.GetName(teacher.TeacherID);

            course_Ent.Teacher = teacher;

            if (!(course_DAL.Edit(course_Ent)))
            {
                Teacher_DAL teacher_DAL = new Teacher_DAL();
                ViewBag.Teachers = teacher_DAL.GetTeachers();
                ViewBag.Message = "Có Lỗi Xảy Ra !";
                return View();
            }

            return RedirectToAction("Course", "Course");
        }

        public ActionResult Detail(int id)
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();
            ViewBag.Teachers = teacher_DAL.GetTeachers();

            Course_DAL course_DAL = new Course_DAL();

            return View(course_DAL.GetCourse_Ent(id));
        }

        public ActionResult Delete(int id)
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();
            ViewBag.Teachers = teacher_DAL.GetTeachers();

            Course_DAL course_DAL = new Course_DAL();

            return View(course_DAL.GetCourse_Ent(id));
        }

        public ActionResult Delete_Accept(int id)
        {
            Course_DAL course_DAL = new Course_DAL();

            if (!course_DAL.Delete(id))
            {
                Teacher_DAL teacher_DAL = new Teacher_DAL();

                ViewBag.Teachers = teacher_DAL.GetTeachers();
                ViewBag.Message = "Có Lỗi Xảy Ra !";

                return View(course_DAL.GetCourse_Ent(id));
            }

            return RedirectToAction("Course", "Course");
        }
    }
}