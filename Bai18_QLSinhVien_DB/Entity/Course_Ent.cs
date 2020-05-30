using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Course_Ent
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public Teacher_Ent Teacher { get; set; }
    }
}
