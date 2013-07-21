using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using StudentsSystem.Model;

namespace StudentsSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentsDBConnection")
        {

        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
