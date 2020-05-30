using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst
{
    public class Student
    {
        [Key]
        public int  StudentID { get; set; }
        public string StudentName { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}
