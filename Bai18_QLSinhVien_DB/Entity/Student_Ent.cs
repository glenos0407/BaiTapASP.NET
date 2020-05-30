using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Student_Ent
    {
        public int StudentID { get; set; }

        [Required]
        [RegularExpression("^([A-Z][a-z]+(\\s)?)+$", ErrorMessage ="Họ Tên Không Hợp Lệ !")]
        public string StudentName { get; set; }
    }
}
