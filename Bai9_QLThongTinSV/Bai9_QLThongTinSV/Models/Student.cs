using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai9_QLThongTinSV.Models
{
    public class Student
    {
        public Student(int studentID, string fullName, DateTime dateOfBirth, string avatar)
        {
            StudentID = studentID;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Avatar = avatar;
        }

        public Student() { }
        

        public int StudentID { get; set; }
        public string FullName { get; set; }       
        public DateTime DateOfBirth { get; set; }       
        public string Avatar { get; set; }       
    }
}