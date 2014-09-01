namespace StudentSystem.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemDbContext>
    {
        private static Random randomGenerator = new Random();
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            ContextKey = "StudentSystem.DataLayer.StudentsSystemDbContext";
        }

        protected override void Seed(StudentsSystemDbContext context)
        {
            var students = context.Students.ToList();
            var studentsPresent = context.Students.Any();
            var coursesPresent = context.Courses.Any();
            var homeworksPresent = context.Homeworks.Any();
            if (studentsPresent == false)
            {
                this.SeedStudents(context);
            }

            if (coursesPresent == false)
            {
                this.SeedCourses(context);
            }

            if (homeworksPresent == false)
            {
                this.SeedHomeworks(context);
            }
        }

        private string GetRandomStudentNumber()
        {
            return randomGenerator.Next(10000000, 99999999).ToString();
        }

        private string GetRandomString(int minLenght, int maxLength)
        {
            var length = randomGenerator.Next(minLenght, maxLength + 1);
            StringBuilder generatedString = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                generatedString.Append(GetRandomChar());
            }

            if (generatedString.Length > 0)
            {
                generatedString[0] = (char)((int)generatedString[0] - 32);
            }

            return generatedString.ToString();
        }

        private DateTime GetRandomDate()
        {
            var year = randomGenerator.Next(2010, 2015);
            var month = randomGenerator.Next(1, 12);
            int maxDay;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    maxDay = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    maxDay = 30;
                    break;
                case 2:
                    maxDay = 28; // TODO: logic for leap year
                    break;
                default:
                    throw new ArgumentException("Incorrect month generated");
            }
            var day = randomGenerator.Next(1, maxDay);
            return new DateTime(year, month, day);
        }

        private char GetRandomChar()
        {
            return (char)randomGenerator.Next(97, 123);
        }

        private void SeedStudents(StudentsSystemDbContext context)
        {
            for (int i = 0; i < 20; i++)
            {
                context.Students.Add(new Student
                {
                    Name = GetRandomString(10, 30),
                    Number = GetRandomStudentNumber()
                });
            }
            context.SaveChanges();
        }
        private void SeedCourses(StudentsSystemDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Courses.Add(new Course
                {
                    Name = GetRandomString(10, 20),
                    Description = GetRandomString(0, 100),
                    Materials = GetRandomString(20, 50),
                    StartDate = GetRandomDate(),
                    EndDate = GetRandomDate(),
                });
            }
            context.SaveChanges();
        }

        private void SeedHomeworks(StudentsSystemDbContext context)
        {
            var coursesIDs = context.Courses.Select(c => c.Id).ToList();
            foreach(Student student in context.Students)
            {
                var randomCourseID = randomGenerator.Next(1, coursesIDs.Count()+1);
                context.Homeworks.Add(new Homework
                {
                     StudentId = student.Id,
                     CourseId = randomCourseID,
                     TimeSent = GetRandomDate(),
                     Content = GetRandomString(50,500)
                });
            }
            context.SaveChanges();
        }
    }
}
