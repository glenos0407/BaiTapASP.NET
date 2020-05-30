using DAL.Codefirst;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Teacher_DAL
    {
        SchoolDBContext db;

        public Teacher_DAL()
        {
            db = new SchoolDBContext();
        }

        public List<Teacher_Ent> GetTeachers()
        {
            List<Teacher_Ent> teachers = new List<Teacher_Ent>();

            foreach (Teacher teacher in db.Teachers)
            {
                Teacher_Ent teacher_Ent = new Teacher_Ent();

                teacher_Ent.TeacherID = teacher.TeacherID;
                teacher_Ent.TeacherName = teacher.TeacherName;

                teachers.Add(teacher_Ent);
            }

            return teachers;
        }

        public Boolean Check_Exist(int id)
        {
            if (db.Teachers.Where(t => t.TeacherID == id).FirstOrDefault() != null)
            {
                return false;
            }

            return true;
        }

        public Teacher_Ent GetTeacher_Ent(int id)
        {
            Teacher temp = db.Teachers.Where(t => t.TeacherID == id).FirstOrDefault();
            Teacher_Ent teacher_Ent = new Teacher_Ent();

            if (temp != null)
            {
                teacher_Ent.TeacherID = temp.TeacherID;
                teacher_Ent.TeacherName = temp.TeacherName;
            }

            return teacher_Ent;
        }

        public Boolean Add(Teacher_Ent teacher_ent)
        {
            try
            {
                Teacher teacher = new Teacher();

                teacher.TeacherID = teacher_ent.TeacherID;
                teacher.TeacherName = teacher_ent.TeacherName;
                
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Boolean Edit(Teacher_Ent teacher_ent)
        {
            Teacher temp = db.Teachers.Where(t => t.TeacherID == teacher_ent.TeacherID).FirstOrDefault();

            if (temp == null)
            {
                return false;
            }

            try
            {
                temp.TeacherName = teacher_ent.TeacherName;
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
            Teacher temp = db.Teachers.Where(t => t.TeacherID == id).FirstOrDefault();

            if (temp == null)
            {
                return false;
            }

            try
            {
                db.Teachers.Remove(temp);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public string GetName(int id)
        {
            Teacher temp = db.Teachers.Where(t => t.TeacherID == id).FirstOrDefault();
            return temp.TeacherName;
        }
    }
}
