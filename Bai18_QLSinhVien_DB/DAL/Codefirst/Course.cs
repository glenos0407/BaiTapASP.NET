using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public int TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
    }
}
