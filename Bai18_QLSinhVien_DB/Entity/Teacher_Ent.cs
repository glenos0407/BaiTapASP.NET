using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Teacher_Ent
    {
        public int TeacherID { get; set; }

        [Required]
        [RegularExpression("^([A-Z][a-z]+(\\s)?)+$", ErrorMessage = "Họ Tên Không Hợp Lệ !")]
        public string TeacherName { get; set; }
    }
}
