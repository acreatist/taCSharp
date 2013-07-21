using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StudentsSystem.Model
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage="A Student Number is required")]
        public string Number { get; set; }

        public virtual ICollection<Course> Courses {
            get
            {
                return this.courses;
            }
            set 
            {
                this.courses = value;
            } 
        }

        public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
