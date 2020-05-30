using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DAL.Codefirst;
using Entity;

namespace DAL
{
    public class Course_DAL
    {
        SchoolDBContext db;

        public Course_DAL()
        {
            db = new SchoolDBContext();
        }

        public List<Course_Ent> GetCourses()
        {
            Teacher_DAL teacher_DAL = new Teacher_DAL();
            List<Course_Ent> courses = new List<Course_Ent>();

            foreach (Course course in db.Courses.ToList())
            {
                Course_Ent course_ent = new Course_Ent();

                course_ent.CourseID = course.CourseID;
                course_ent.CourseName = course.CourseName;
                course_ent.Location = course.Location;
                
                Teacher_Ent teacher_Ent = new Teacher_Ent();
                teacher_Ent.TeacherID = course.TeacherID;
                teacher_Ent.TeacherName = teacher_DAL.GetName(course.TeacherID);

                course_ent.Teacher = teacher_Ent;

                courses.Add(course_ent);
            }

            return courses;
        }

        public Boolean Check_Exist(int id)
        {
            if (db.Courses.Where(c => c.CourseID == id).FirstOrDefault() != null)
            {
                return false;
            }

            return true;
        }

        public Boolean Add_Course(Course_Ent course_Ent)
        {
            try
            {
                Course course = new Course();
                course.CourseID = course_Ent.CourseID;
                course.CourseName = course_Ent.CourseName;
                course.Location = course_Ent.Location;
                course.TeacherID = course_Ent.Teacher.TeacherID;

                db.Courses.Add(course);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Boolean Add_Register(int id_course, int id_student)
        {
            try
            {
                Register register = new Register();
                register.CourseID = id_course;
                register.StudentID = id_student;

                db.Registers.Add(register);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Course_Ent GetCourse_Ent(int id)
        {
            Course course = db.Courses.Where(c => c.CourseID == id).FirstOrDefault();
            Course_Ent course_Ent = new Course_Ent();
            Teacher_DAL teacher_DAL = new Teacher_DAL();
            Teacher_Ent teacher_Ent = new Teacher_Ent();

            course_Ent.CourseID = course.CourseID;
            course_Ent.CourseName = course.CourseName;
            course_Ent.Location = course.Location;
            teacher_Ent.TeacherID = course.TeacherID;
            teacher_Ent.TeacherName = teacher_DAL.GetName(course.TeacherID);
            course_Ent.Teacher = teacher_Ent;

            return course_Ent;
        }

        public Boolean Edit(Course_Ent course_Ent)
        {
            Course course = db.Courses.Where(c => c.CourseID == course_Ent.CourseID).FirstOrDefault();

            if(course == null) { return false; }

            try
            {
                course.CourseName = course_Ent.CourseName;
                course.Location = course_Ent.Location;
                course.TeacherID = course_Ent.Teacher.TeacherID;

                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Boolean Delete(int id)
        {
            Course course = db.Courses.Where(c => c.CourseID == id).FirstOrDefault();

            try
            {
                db.Courses.Remove(course);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
