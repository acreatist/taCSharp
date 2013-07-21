namespace StudentsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentsSystem.Data;
    using StudentsSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsSystem.Data.StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Courses.AddOrUpdate(new Course { Name = "Javascript", Description = "JS Course" });
            context.Courses.AddOrUpdate(new Course { Name = "Javascript II", Description = "JS Advanced Course" });
            context.Courses.AddOrUpdate(new Course { Name = "Javascript Applications", Description = "JS Applications Course" });
        }
    }
}
