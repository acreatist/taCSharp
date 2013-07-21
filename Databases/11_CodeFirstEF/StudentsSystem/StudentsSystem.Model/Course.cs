using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StudentsSystem.Model
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        [Key]
        public int CourseId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Materials { get; set; }

        public ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }
    }
}
