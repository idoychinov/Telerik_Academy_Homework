namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;
        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }


        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        
        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value;}
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value;}
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Description: {2}, Materials: {3}, Start date: {4}, End date: {5} "
                , this.Id, this.Name, this.Description, this.Materials, this.StartDate, this.StartDate);
        }
    }
}
