using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst
{
    public class Register
    {
        [Key]
        [Column(Order = 1)]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        [Key]
        [Column(Order = 2)]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}
