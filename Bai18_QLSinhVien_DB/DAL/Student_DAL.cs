using DAL.Codefirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Reflection;

namespace DAL
{
    public class Student_DAL
    {
        SchoolDBContext db;

        public Student_DAL()
        {
            db = new SchoolDBContext();
        }

        public List<Student_Ent> GetStudents() {
            List<Student_Ent> students = new List<Student_Ent>();

            foreach (Student student in db.Students)
            {
                Student_Ent student_Ent = new Student_Ent();

                student_Ent.StudentID = student.StudentID;
                student_Ent.StudentName = student.StudentName;

                students.Add(student_Ent);
            }

            return students; 
        }

        public Boolean Check_Exist(int id)
        {
            if(db.Students.Where(s => s.StudentID == id).FirstOrDefault() != null)
            {
                return false;
            }

            return true;
        }

        public Student_Ent GetStudent_Ent(int id)
        {
            Student temp = db.Students.Where(s => s.StudentID == id).FirstOrDefault();
            Student_Ent student_Ent = new Student_Ent();

            if (temp != null)
            {
                student_Ent.StudentID = temp.StudentID;
                student_Ent.StudentName = temp.StudentName;
            }

            return student_Ent;
        }

        public int GetID_byName(string name)
        {
            return db.Students.Where(s => s.StudentName.Equals(name)).FirstOrDefault().StudentID;
        }

        public Boolean Add(Student_Ent stu_ent)
        {
            try
            {
                Student student = new Student();
                student.StudentName = stu_ent.StudentName;

                db.Students.Add(student);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Boolean Edit(Student_Ent stu_ent)
        {
            Student temp = db.Students.Where(s => s.StudentID == stu_ent.StudentID).FirstOrDefault();

            if (temp == null)
            {
                return false;
            }

            try
            {
                temp.StudentName = stu_ent.StudentName;
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Boolean Delete(int id) {
            Student temp = db.Students.Where(s => s.StudentID == id).FirstOrDefault();

            if (temp == null)
            {
                return false;
            }

            try
            {
                db.Students.Remove(temp);
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
