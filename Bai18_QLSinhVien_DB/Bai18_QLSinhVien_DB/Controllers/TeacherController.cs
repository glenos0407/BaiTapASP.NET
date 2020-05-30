using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Entity;

namespace Bai18_QLSinhVien_DB.Controllers
{
    public class TeacherController : Controller
    {
        public ActionResult Teacher()
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();

            return View(teacher_DAL.GetTeachers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher_Ent teacher_Ent)
        {
            if (ModelState.IsValid)
            {
                Teacher_DAL teacher_DAL = new Teacher_DAL();

                if (!(teacher_DAL.Check_Exist(teacher_Ent.TeacherID)))
                {
                    ViewBag.Message = "ID Tồn Tại !";
                    return View();
                }

                if (!(teacher_DAL.Add(teacher_Ent)))
                {
                    ViewBag.Message = "Có Lỗi Xảy Ra !";
                    return View();
                }
            }

            return RedirectToAction("Teacher", "Teacher");
        }

        public ActionResult Edit(int id)
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();

            return View(teacher_DAL.GetTeacher_Ent(id));
        }

        [HttpPost]
        public ActionResult Edit(Teacher_Ent teacher_Ent)
        {
            if (ModelState.IsValid)
            {
                Teacher_DAL teacher_DAL = new Teacher_DAL();

                if (!(teacher_DAL.Edit(teacher_Ent)))
                {
                    ViewBag.Message = "Có Lỗi Xảy Ra !";
                    return View();
                }
            }

            return RedirectToAction("Teacher", "Teacher");
        }

        public ActionResult Delete(int id)
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();

            return View(teacher_DAL.GetTeacher_Ent(id));
        }

        [HttpPost]
        public ActionResult Delete_Accept(int id)
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();

            if (!(teacher_DAL.Delete(id)))
            {
                ViewBag.Message = "Có Lỗi Xảy Ra !";
                return View("Delete", id);
            }

            return RedirectToAction("Teacher", "Teacher");
        }

        public ActionResult Detail(int id)
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();

            return View(teacher_DAL.GetTeacher_Ent(id));
        }
    }
}