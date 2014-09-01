namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;
        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]

        public string Name { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        public string Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Number: {2} ", this.Id, this.Name, this.Number);
        }
    }
}
