using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentsSystem.Data;
using StudentsSystem.Model;
using StudentsSystem.Data.Migrations;
using System.Data.Entity;

namespace StudentsSystem.Client
{
    class ConsoleStudetnSystem
    {
        static void Main()
        {
            /* Well, the model works, adding a course, student and a homework is ok - relations seem right.
             * We've got seeding as well.
             * Sorry, that the console application is so poor on functionality, but a lot of homeworks need to be done
             * For the sake of the demo, I hope this will be enough
             * Thanks!
             * */

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            StudentSystemContext ctx = new StudentSystemContext();

            using (ctx)
            {
                var course = new Course { Name = "Javascript", Description = "JS Course Description" };
                ctx.Courses.Add(course);

                var student = new Student { Name = "Pesho Peshov", Number = "1" };
                ctx.Students.Add(student);
                course.Students.Add(student);

                var homework = new Homework { Content = "JS Homework", Course = course, Student = student };
                ctx.Homeworks.Add(homework);

                ctx.SaveChanges();

                Console.WriteLine("Ready.");
            }
        }
    }
}
