using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Codefirst;

namespace DAL
{
    public class SchoolDBContext:DbContext
    {
        public SchoolDBContext():base("SchoolDBConnectionString") {}

        public DbSet<Course> Courses { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
